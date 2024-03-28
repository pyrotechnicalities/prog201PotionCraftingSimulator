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
        Player player = new Player()
        {
            Inventory = new List<Item>()
        };
        Vendor vendor = new Vendor()
        {
            Inventory = new List<Item>()
        };
        Recipe recipe = new Recipe();
        List<Recipe> Recipes = new List<Recipe>();

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
        public string Trade()
        {
            ShowInventory("vendor");
            return "\nTrade is not yet functional.\n";
        }
        public string ShowRecipes()
        {
            string output = "Recipes:\n";
            foreach (Recipe r in Recipes)
            {
                output += $"  * {r.GetRecipeDescription()}\n";
            }
            return output;
        }
        public string ShowInventory(string p)
        {
            Person person = player;
            if (p == "vendor") person = vendor;

            string output = $"Current inventory:\n";
            foreach (Item i in person.Inventory)
            {
                output += $"  * {i.ItemName} ({i.ItemAmount})\n";
            }
            return output;
        }
        public string ShowPlayerName() => player.Name;
        public string ShowPlayerNameAndCurrency() => $"{player.Name} {player.Currency.ToString("c")}";
        public void SetPlayerName(string name) { player.Name = name; }
    }
}
