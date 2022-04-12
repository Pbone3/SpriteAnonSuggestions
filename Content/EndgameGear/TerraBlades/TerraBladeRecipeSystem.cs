using SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Items;
using SpriteAnonSuggestions.Utils;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.EndgameGear.TerraBlades
{
    public sealed class TerraBladeRecipeSystem : ModSystem
    {
        public sealed override void PostAddRecipes()
        {
            // Green Terra Blade can only be crafted during day
            IEnumerable<Recipe> matchingRecipes =
                from recipe in Main.recipe
                where recipe.createItem.type == ItemID.TerraBlade
                where recipe.HasIngredient(ItemID.TrueNightsEdge)
                where recipe.HasIngredient(ItemID.TrueExcalibur)
                select recipe;

            Recipe terraBladeRecipe = matchingRecipes.First();
            terraBladeRecipe.Conditions.Add(new Recipe.Condition(NetworkText.FromKey(L10nUtils.GetModKey("RecipeConditions.DayOnly")), recipe => Main.dayTime));

            // Add recipes to switch between the Terra Blades
            Mod.CreateRecipe(ItemID.TerraBlade)
                .AddIngredient(ModContent.ItemType<NightTerraBlade>())
                .AddTile(TileID.DemonAltar)
                .AddOnCraftCallback(new Recipe.OnCraftCallback((recipe, item) => {
                    item.Prefix(0); // We don't want people to farm good prefixes off this craft
                }))
                .Register();

            Mod.CreateRecipe(ModContent.ItemType<NightTerraBlade>())
                .AddIngredient(ItemID.TerraBlade)
                .AddTile(TileID.DemonAltar)
                .AddOnCraftCallback(new Recipe.OnCraftCallback((recipe, item) => {
                    item.Prefix(0); // We don't want people to farm good prefixes off this craft
                }))
                .Register();
        }
    }
}
