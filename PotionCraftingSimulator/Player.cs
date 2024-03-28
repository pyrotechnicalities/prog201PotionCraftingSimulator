using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Player : Person
    {
        // generalized craft algorithm 
        public Item CraftItem(Recipe recipe)
        {
            //if all the required elements for the recipe are in the player's inventory
            // AND the amounts of those elements are equal to or greater than what is specified in the recipe
            // then remove the ingredient items from the player's inventory or modify the amounts of the items
            // and return an instance of the Item class that matches the recipe
            return Item;
        }
    }
}
