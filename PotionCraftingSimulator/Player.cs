using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;

namespace PotionCraftingSimulator
{
    internal class Player : Person, ITrade
    {
        public new double Currency = 0.00;
        
        // generalized craft algorithm 
        // Assistance with CraftItem and connected methods from Janell Baxter
        public string CraftItem(Recipe recipe)
        {
            string output = "Item could not be created.";
            foreach (Item items in recipe.RecipeRequirements)
            {
                if (IsInInventory(items.ItemName) && GetAmount(items.ItemName) >= recipe.RecipeAmount)
                {
                    output = GenerateItem(recipe);
                    break;
                }
                else
                {
                    output = $"{items.ItemName} was not found.";
                    break;
                }
            }
            return output;
        }
        private string GenerateItem(Recipe recipe)
        {
            bool IsNormal = false;
            bool IsRare = false;
            bool IsSuperRare = false;
            string output = " ";
            Random random = new Random();
            int i = random.Next(1, 11);
            foreach (Item item in recipe.RecipeRequirements)
            {
                SubtractAmount(item.ItemName, item.ItemAmount);
            }

            // Help with switch statement from https://stackoverflow.com/questions/68578/multiple-cases-in-switch-statement

            switch (i)
            {
                case int when (i >= 1 && i <= 7):
                    IsNormal = true;
                    output = $"Your item is regular quality.";
                    break;
                case int when (i == 8 || i == 9):
                    IsRare = true;
                    output = "Your item is rare quality! It is worth two times the normal price.";
                    break;
                case int when (i == 10):
                    IsSuperRare = true;
                    output = "Your item is legendary quality! It is worth five times the normal price.";
                    break;
            }

            if (IsNormal == true)
            {
                Item tempItem = new Item() { ItemName = recipe.RecipeName, ItemAmount = recipe.RecipeAmount, ItemAmountType = recipe.RecipeAmountType, ItemDescription = recipe.RecipeDescription, ItemValue = recipe.RecipeValue };
                CheckAndAddItem(tempItem);
            }
            else if (IsRare == true)
            {
                Item tempItem = new Item() { ItemName = "Rare " + recipe.RecipeName, ItemAmount = recipe.RecipeAmount, ItemAmountType = recipe.RecipeAmountType, ItemDescription = recipe.RecipeDescription, ItemValue = recipe.RecipeValue * 2 };
                CheckAndAddItem(tempItem);
            }
            else if (IsSuperRare == true)
            {
                Item tempItem = new Item() { ItemName = "Legendary " + recipe.RecipeName, ItemAmount = recipe.RecipeAmount, ItemAmountType = recipe.RecipeAmountType, ItemDescription = recipe.RecipeDescription, ItemValue = recipe.RecipeValue * 5 };
                CheckAndAddItem(tempItem);
            }

            return "The item was created." + $" {output}";
        }
        private void CheckAndAddItem(Item item)
        {
            if (IsInInventory(item.ItemName))
            {
                AddAmount(item.ItemName, 1);
            }
            else
            {
                Inventory.Add(item);
            }
        }
        public void Buy()
        {
            // buy code
        }
        public void Sell()
        {
            // sell code
        }
    }
}
