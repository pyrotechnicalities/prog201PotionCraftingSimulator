using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Player : Person
    {
        public new double Currency = 0;
        public Player()
        {
            Inventory = new List<Item>
            {
                new Item() {ItemName = "Water", ItemDescription = "Basic drinking water.", ItemValue = 0.15, ItemAmount = 15, ItemAmountType = "cup(s)" },
                new Item() {ItemName = "Chamomile", ItemDescription = "A portion of dried chamomile leaves.", ItemValue = .30, ItemAmount = 5, ItemAmountType = "tsp"},
                new Item() {ItemName = "Ashwagandha", ItemDescription = "An herb commonly used to reduce stress and promote better sleep.", ItemValue = .75, ItemAmount = 4, ItemAmountType = "tsp"},

            };
        }
        // generalized craft algorithm 
        // Assistance with CraftItem and connected methods from Janell Baxter
        public string CraftItem(Recipe recipe)
        {
            string output = "Item could not be created.";
            foreach (Item items in recipe.RecipeRequirements)
            {
                if (IsInInventory(items.ItemName) && GetAmount(items.ItemName) >= items.ItemAmount)
                {
                    output = GenerateItem(recipe);
                    break;
                }
                else
                {
                    output = $"{items.ItemName} was not found.";
                }
            }
            return output;
        }
        private string GenerateItem(Recipe recipe)
        {
            foreach (Item item in recipe.RecipeRequirements)
            {
                ChangeAmount(item.ItemName, item.ItemAmount);
            }
            Inventory.Add(new Item() {ItemName = recipe.RecipeName, ItemAmount = recipe.RecipeAmount, ItemAmountType = recipe.RecipeAmountType, ItemDescription = recipe.RecipeDescription, ItemValue = recipe.RecipeValue });
            return "The item was created!";
        }
    }
}
