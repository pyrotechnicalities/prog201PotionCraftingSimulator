using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Vendor : Person
    {
        public Vendor()
        {
            Name = "Vendor";
            Inventory = new List<Item>
            {
                new() {ItemName = "Water", ItemDescription = "Basic drinking water.", ItemValue = 0.15, ItemAmount = 8, ItemAmountType = "cup(s)"},
                new() {ItemName = "Chamomile", ItemDescription = "A portion of dried chamomile leaves.", ItemValue = .30, ItemAmount = 4, ItemAmountType = "tsp"},
                new() {ItemName = "Ashwagandha", ItemDescription = "An herb commonly used to reduce stress and promote better sleep.", ItemValue = .75, ItemAmount = 2, ItemAmountType = "tsp"},
                new() {ItemName = "Dried Lavender", ItemDescription = "A purple flower commonly used to treat insomnia.", ItemValue = .55, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Lemon Balm", ItemDescription = "A lemony-scented herb commonly used to reduce stress and treat insomnia and/or anxiety.", ItemValue = .40, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Slime", ItemDescription = "A tube of freshly harvested monster slime. Better not drink this by itself...", ItemValue = 0.50, ItemAmount = 8, ItemAmountType = "bottle(s)"},
                new() {ItemName = "Dried St. John's Wort", ItemDescription = "A medicinal herb commonly used to promote wound healing.", ItemValue = .85, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Green Tea", ItemDescription = "A slightly bitter tea that improves your memory and focus.", ItemValue = 1.50, ItemAmount = 2, ItemAmountType = "mug"},
                new() {ItemName = "Dried Sage", ItemDescription = "An aromatic herb that can increase brain function in areas related to memory and attention.", ItemValue = .35, ItemAmount = 1.5, ItemAmountType = "tsp"},
                new() {ItemName = "Concentrated Cat's Purr", ItemDescription = "A mysterious vial that somehow contains a cat's purr in liquid form. Don't ask us how we got it. Has stress-reducing capabilities.", ItemValue = 6.00, ItemAmount = 2, ItemAmountType = "vial"},
                new() {ItemName = "Licorice Extract", ItemDescription = "For taste!", ItemValue = 1.50, ItemAmount = 4, ItemAmountType = "cups"},
                new() {ItemName = "Vanilla Extract", ItemDescription = "A sweet substance that promotes pure love.", ItemValue = 2.50, ItemAmount = 4, ItemAmountType = "tsp"},
                new() {ItemName = "Apple Juice", ItemDescription = "Tasty juice made from the best apples money can buy. Promotes romance!", ItemValue = 3.00, ItemAmount = 4, ItemAmountType = "cups"},
                new() {ItemName = "Cinnamon", ItemDescription = "A spicy tasting herb to ~spice~ up your romance.", ItemValue = .40, ItemAmount = 1, ItemAmountType = "tsp"},
                new() {ItemName = "Unicorn Horn Shavings", ItemDescription = "A very rare substance that can only be harvested by those pure enough of heart to approach a unicorn. Has very powerful protective properties.", ItemValue = 40.00, ItemAmount = 2, ItemAmountType = "pinch"},
                new() {ItemName = "Red Wine", ItemDescription = "An alcoholic beverage said to act as an aphrodisiac.", ItemValue = 50.00, ItemAmount = 4, ItemAmountType = "cups"}
            };
        }
    }
}
