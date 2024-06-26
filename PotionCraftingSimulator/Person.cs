﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PotionCraftingSimulator
{
    internal class Person
    {
        public string Name { get; set; }
        public double Currency { get; set; }
        public List<Item> Inventory = new List<Item>();

        public bool IsInInventory(string name)
        {
            foreach (Item item in Inventory)
            {
                if (item.ItemName == name) return true;
            }
            return false;
        }
        public double GetAmount(string name)
        {
            foreach(Item item in Inventory)
            {
                if (item.ItemName == name) return item.ItemAmount;
            }
            return 0;
        }
        public void SubtractAmount(string name, double amount)
        {
            foreach(Item item in Inventory)
            {
                if (item.ItemName == name) item.ItemAmount -= amount;
            }
        }
        public void AddAmount(string name, double amount)
        {
            foreach (Item item in Inventory)
            {
                if (item.ItemName == name) item.ItemAmount += amount;
            }
        }
        public string ShowInventory()
        {
            int number = 1;
            string output = $"{Name}'s current inventory:\n";
            foreach (Item i in Inventory)
            {
                output += $"  {number}. {i.ItemName} ({i.ItemAmount} {i.ItemAmountType}, {i.ItemValue.ToString("C")} each)\n";
                number++;
            }
            return output;
        }
        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }
    }
}
