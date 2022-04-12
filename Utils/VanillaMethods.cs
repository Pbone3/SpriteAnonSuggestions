using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace SpriteAnonSuggestions.Utils
{
    public static class VanillaMethods
    {
        public static void ItemCheck_GetMeleeHitboxPUB(this Player player, Item sItem, Rectangle heldItemFrame, out bool dontAttack, out Rectangle itemRectangle)
		{
			dontAttack = false;
			itemRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, 32, 32);
			if (!Main.dedServ)
			{
				int num = heldItemFrame.Width;
				int num2 = heldItemFrame.Height;
				switch (sItem.type)
				{
					case 5094:
						num -= 10;
						num2 -= 10;
						break;
					case 5095:
						num -= 10;
						num2 -= 10;
						break;
					case 5096:
						num -= 12;
						num2 -= 12;
						break;
					case 5097:
						num -= 8;
						num2 -= 8;
						break;
				}

				itemRectangle = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, num, num2);
			}

			float adjustedItemScale = player.GetAdjustedItemScale(sItem);
			itemRectangle.Width = (int)(itemRectangle.Width * adjustedItemScale);
			itemRectangle.Height = (int)(itemRectangle.Height * adjustedItemScale);
			if (player.direction == -1)
				itemRectangle.X -= itemRectangle.Width;

			if (player.gravDir == 1f)
				itemRectangle.Y -= itemRectangle.Height;

			if (sItem.useStyle == 1)
			{
				if (player.itemAnimation < player.itemAnimationMax * 0.333)
				{
					if (player.direction == -1)
						itemRectangle.X -= (int)(itemRectangle.Width * 1.4 - itemRectangle.Width);

					itemRectangle.Width = (int)(itemRectangle.Width * 1.4);
					itemRectangle.Y += (int)(itemRectangle.Height * 0.5 * player.gravDir);
					itemRectangle.Height = (int)(itemRectangle.Height * 1.1);
				}
				else if (!(player.itemAnimation < player.itemAnimationMax * 0.666))
				{
					if (player.direction == 1)
						itemRectangle.X -= (int)(itemRectangle.Width * 1.2);

					itemRectangle.Width *= 2;
					itemRectangle.Y -= (int)((itemRectangle.Height * 1.4 - itemRectangle.Height) * player.gravDir);
					itemRectangle.Height = (int)(itemRectangle.Height * 1.4);
				}
			}
			else if (sItem.useStyle == 3)
			{
				if (player.itemAnimation > player.itemAnimationMax * 0.666)
				{
					dontAttack = true;
				}
				else
				{
					if (player.direction == -1)
						itemRectangle.X -= (int)(itemRectangle.Width * 1.4 - itemRectangle.Width);

					itemRectangle.Width = (int)(itemRectangle.Width * 1.4);
					itemRectangle.Y += (int)(itemRectangle.Height * 0.6);
					itemRectangle.Height = (int)(itemRectangle.Height * 0.6);
					if (sItem.type == 946 || sItem.type == 4707)
					{
						itemRectangle.Height += 14;
						itemRectangle.Width -= 10;
						if (player.direction == -1)
							itemRectangle.X += 10;
					}
				}
			}

			if (sItem.type == ItemID.BubbleWand && Main.rand.Next(3) == 0)
			{
				int num3 = -1;
				float x = itemRectangle.X + Main.rand.Next(itemRectangle.Width);
				float y = itemRectangle.Y + Main.rand.Next(itemRectangle.Height);
				if (Main.rand.Next(500) == 0)
					num3 = Gore.NewGore(new Vector2(x, y), default(Vector2), 415, Main.rand.Next(51, 101) * 0.01f);
				else if (Main.rand.Next(250) == 0)
					num3 = Gore.NewGore(new Vector2(x, y), default(Vector2), 414, Main.rand.Next(51, 101) * 0.01f);
				else if (Main.rand.Next(80) == 0)
					num3 = Gore.NewGore(new Vector2(x, y), default(Vector2), 413, Main.rand.Next(51, 101) * 0.01f);
				else if (Main.rand.Next(10) == 0)
					num3 = Gore.NewGore(new Vector2(x, y), default(Vector2), 412, Main.rand.Next(51, 101) * 0.01f);
				else if (Main.rand.Next(3) == 0)
					num3 = Gore.NewGore(new Vector2(x, y), default(Vector2), 411, Main.rand.Next(51, 101) * 0.01f);

				if (num3 >= 0)
				{
					Main.gore[num3].velocity.X += player.direction * 2;
					Main.gore[num3].velocity.Y *= 0.3f;
				}
			}

			if (sItem.type == ItemID.NebulaBlaze)
				dontAttack = true;

			if (sItem.type == ItemID.SpiritFlame)
			{
				dontAttack = true;
				Vector2 vector = player.itemLocation + new Vector2(player.direction * 30, -8f);
				Vector2 value = vector - player.position;
				for (float num4 = 0f; num4 < 1f; num4 += 0.2f)
				{
					Vector2 position = Vector2.Lerp(player.oldPosition + value + new Vector2(0f, player.gfxOffY), vector, num4);
					Dust obj = Main.dust[Dust.NewDust(vector - Vector2.One * 8f, 16, 16, DustID.Shadowflame, 0f, -2f)];
					obj.noGravity = true;
					obj.position = position;
					obj.velocity = new Vector2(0f, (0f - player.gravDir) * 2f);
					obj.scale = 1.2f;
					obj.alpha = 200;
				}
			}
		}
	}
}
