using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Vendor : Person, ITrade
    {
        public Vendor()
        {
            Name = "Vendor";
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
