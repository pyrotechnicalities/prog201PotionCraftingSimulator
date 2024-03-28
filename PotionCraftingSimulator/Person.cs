using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Person
    {
        public string Name { get; set; }
        public double Currency { get; set; }
        public List<Item> Inventory = new List<Item>();
    }
}
