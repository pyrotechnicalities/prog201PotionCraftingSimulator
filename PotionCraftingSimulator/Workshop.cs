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
        public Player player = new Player()
        {
            Inventory = new List<Item>()
        };
        Vendor vendor = new Vendor();
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

            string output = $"The vendor's current inventory:\n";
            foreach (Item i in person.Inventory)
            {
                output += $"  * {i.ItemName} ({i.ItemAmount})\n";
            }
            return output;
        }
        public bool CheckIfInputIsValid(string s)
        {
            Person person = player;
            Item tempItem = person.Inventory.Find(tempItem => tempItem.ItemName.Equals(s, StringComparison.InvariantCultureIgnoreCase));

            if (tempItem  != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string ShowPlayerName() => player.Name;
        public string ShowPlayerNameAndCurrency() => $"{player.Name} {player.Currency.ToString("c")}";
        public void SetPlayerName(string name) { player.Name = name; }
    }
}
