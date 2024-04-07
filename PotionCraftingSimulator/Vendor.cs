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
            Inventory = new List<Item>
            {
                new Item() {ItemName = "Water", ItemDescription = "Basic drinking water.", ItemValue = 0.15, ItemAmount = 15, ItemAmountType = "cup(s)" },
                new Item() {ItemName = "Chamomile", ItemDescription = "A portion of dried chamomile leaves.", ItemValue = .30, ItemAmount = 5, ItemAmountType = "tsp"}
            };
        }
    }
}
