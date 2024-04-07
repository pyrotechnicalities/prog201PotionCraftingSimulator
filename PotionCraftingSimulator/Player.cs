using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Player : Person
    {
        public new double Currency = 25.00;
        // generalized craft algorithm 
        public string CraftItem()
        {
            string output = "Not working yet";
            //if all the required elements for the recipe are in the player's inventory
            // AND the amounts of those elements are equal to or greater than what is specified in the recipe
            // then remove the ingredient items from the player's inventory or modify the amounts of the items
            // and return an instance of the Item class that matches the recipe
            return output;
        }
    }
}
