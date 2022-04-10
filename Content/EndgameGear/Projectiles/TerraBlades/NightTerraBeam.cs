using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.EndgameGear.Projectiles.TerraBlades
{
    // Visual variation of the vanilla green Terra Beam
    public sealed class NightTerraBeam : ModProjectile
    {
        public static int DustType => 71;

        public sealed override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.TerraBeam);
            Projectile.aiStyle = -1;
            AIType = ProjectileID.TerraBeam;
        }

        public sealed override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            // Reduce damage on hit
            Projectile.damage = (int)((float)Projectile.damage * 0.85f);
        }

        public sealed override Color? GetAlpha(Color lightColor)
        {
            if (Projectile.localAI[1] >= 15f)
                return new Color(255, 255, 255, Projectile.alpha);

            if (Projectile.localAI[1] < 5f)
                return Color.Transparent;

            int brightness = (int)((Projectile.localAI[1] - 5f) / 10f * 255f);
            return new Color(brightness, brightness, brightness, brightness);
        }

        public sealed override bool PreDraw(ref Color lightColor)
        {
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
                spriteEffects = SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(
                TextureAssets.Projectile[Type].Value,
                new Vector2(
                    Projectile.position.X - Main.screenPosition.X + (Projectile.width / 2),
                    Projectile.position.Y - Main.screenPosition.Y + (Projectile.height / 2)),
                
                new Rectangle(0, 0, TextureAssets.Projectile[Type].Width(), TextureAssets.Projectile[Type].Height()),
                Projectile.GetAlpha(lightColor), Projectile.rotation,
                new Vector2(TextureAssets.Projectile[Type].Width(), 0f), Projectile.scale, spriteEffects, 0);
            
            return false;
        }

        public sealed override void AI()
        {
            if (Projectile.localAI[1] > 7f) // Dust spawning
            {
                Dust dust =
                    Dust.NewDustDirect(
                        new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f),
                        8, 8, DustType, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.25f);
                dust.velocity *= -0.15f;

                dust =
                    Dust.NewDustDirect(
                        new Vector2(Projectile.position.X - Projectile.velocity.X * 4f + 2f, Projectile.position.Y + 2f - Projectile.velocity.Y * 4f),
                        8, 8, DustType, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.25f); ;
                dust.velocity *= -0.15f;
                dust.position -= Projectile.velocity * 0.5f;
            }

            if (Projectile.localAI[1] < 15f)
            {
                Projectile.localAI[1] += 1f;
            }
            else
            {

                if (Projectile.localAI[0] == 0f)
                {
                    Projectile.scale -= 0.02f;
                    Projectile.alpha += 30;
                    if (Projectile.alpha >= 250)
                    {
                        Projectile.alpha = 255;
                        Projectile.localAI[0] = 1f;
                    }
                }
                else if (Projectile.localAI[0] == 1f)
                {
                    Projectile.scale += 0.02f;
                    Projectile.alpha -= 30;
                    if (Projectile.alpha <= 0)
                    {
                        Projectile.alpha = 0;
                        Projectile.localAI[0] = 0f;
                    }
                }
            }

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                SoundEngine.PlaySound(SoundID.Item60, Projectile.position);
            }

            Projectile.rotation = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 0.785f;

            if (Projectile.velocity.Y > 16f)
                Projectile.velocity.Y = 16f;

            // Light
            float red = Projectile.light * 0.6f;
            float green = Projectile.light * 0.2f;
            float blue = Projectile.light;

            Lighting.AddLight(
                (int)((Projectile.position.X + (Projectile.width / 2)) / 16f),
                (int)((Projectile.position.Y + (Projectile.height / 2)) / 16f),
                red, green, blue);
        }

        public sealed override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 4; i < 31; i++)
            {
                float offsetX = Projectile.oldVelocity.X * (30f / i);
                float offsetY = Projectile.oldVelocity.Y * (30f / i);
                
                Dust dust = Dust.NewDustDirect(
                    new Vector2(Projectile.oldPosition.X - offsetX, Projectile.oldPosition.Y - offsetY),
                    8, 8, DustType, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.8f);
                dust.noGravity = true;
                dust.velocity *= 0.35f;
                
                dust = Dust.NewDustDirect(
                    new Vector2(Projectile.oldPosition.X - offsetX, Projectile.oldPosition.Y - offsetY),
                    8, 8, DustType, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.4f);
                dust.velocity *= 0.035f;
            }
        }
    }
}
