using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Workshop
    {
        public Player player = new Player();
        public Vendor vendor = new Vendor();
        Recipe recipe = new Recipe();
        public List<Recipe> Recipes = new List<Recipe>();

        public Workshop()
        {
            SetPlayerName("Anon");
            Recipes = DataLoader.LoadRecipesFromExternalXMLFile("../../../data/recipes.xml");
        }

        public string GetRecipeList()
        {
            int number = 1;
            string output = "Recipes:\n\n";
            foreach (Recipe recipe in Recipes)
            {
                output += $"  {number}. {recipe.GetRecipeDescription()}";
                number++;
            }
            return output;
        }
        public string ShowRecipes()
        {
            string output = "Recipes:\n";
            int number = 1;
            foreach (Recipe r in Recipes)
            {
                output += $"  {number}. {r.GetRecipeDescription()}\n";
                number++;
            }
            return output;
        }
        public int RecipeCount()
        {
            return Recipes.Count;
        }
        public bool HasMoney(Item item)
        {
            if (player.Currency >= item.ItemValue)
            {
                return true;
            }
            return false;
        }
        public string ShowPlayerName() => player.Name;
        public string ShowPlayerNameAndCurrency() => $"{player.Name} {player.Currency.ToString("c")}";
        public void SetPlayerName(string name) { player.Name = name; }
    }
}
