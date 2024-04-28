using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;

namespace PotionCraftingSimulator
{
    internal class Player : Person
    {
        public new double Currency = 0.00;
        public Player()
        {
            Inventory = new List<Item>
            {
                new() {ItemName = "Water", ItemDescription = "Basic drinking water.", ItemValue = 1.30, ItemAmount = 4, ItemAmountType = "cup(s)"},
                new() {ItemName = "Chamomile", ItemDescription = "A portion of dried chamomile leaves.", ItemValue = 1.40, ItemAmount = 2, ItemAmountType = "tsp"},
                new() {ItemName = "Ashwagandha", ItemDescription = "An herb commonly used to reduce stress and promote better sleep.", ItemValue = 1.50, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Dried Lavender", ItemDescription = "A purple flower commonly used to treat insomnia.", ItemValue = 2.00, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Lemon Balm", ItemDescription = "A lemony-scented herb commonly used to reduce stress and treat insomnia and/or anxiety.", ItemValue = .60, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Slime", ItemDescription = "A tube of freshly harvested monster slime. Better not drink this by itself...", ItemValue = 3.00, ItemAmount = 4, ItemAmountType = "bottle(s)"},
                new() {ItemName = "Dried St. John's Wort", ItemDescription = "A medicinal herb commonly used to promote wound healing.", ItemValue = 1.20, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Green Tea", ItemDescription = "A slightly bitter tea that improves your memory and focus.", ItemValue = 4.00, ItemAmount = 1, ItemAmountType = "mug"},
                new() {ItemName = "Dried Sage", ItemDescription = "An aromatic herb that can increase brain function in areas related to memory and attention.", ItemValue = 1.35, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Concentrated Cat's Purr", ItemDescription = "A mysterious vial that somehow contains a cat's purr in liquid form. Don't ask us how we got it. Has stress-reducing capabilities.", ItemValue = 13.15, ItemAmount = 1, ItemAmountType = "vial"},
                new() {ItemName = "Licorice Extract", ItemDescription = "For taste!", ItemValue = 3.50, ItemAmount = 2, ItemAmountType = "cups"},
                new() {ItemName = "Vanilla Extract", ItemDescription = "A sweet substance that promotes pure love.", ItemValue = 2.50, ItemAmount = 2, ItemAmountType = "tsp"},
                new() {ItemName = "Apple Juice", ItemDescription = "Tasty juice made from the best apples money can buy. Promotes romance!", ItemValue = 3.50, ItemAmount = 2, ItemAmountType = "cups"},
                new() {ItemName = "Cinnamon", ItemDescription = "A spicy tasting herb to ~spice~ up your romance.", ItemValue = .40, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Unicorn Horn Shavings", ItemDescription = "A very rare substance that can only be harvested by those pure enough of heart to approach a unicorn. Has very powerful protective properties.", ItemValue = 40.00, ItemAmount = 1, ItemAmountType = "pinch"},
                new() {ItemName = "Red Wine", ItemDescription = "An alcoholic beverage said to act as an aphrodisiac.", ItemValue = 50.00, ItemAmount = 2, ItemAmountType = "cups"}
            };
        }
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
    }
}
