using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace PotionCraftingSimulator
{
    internal class DataLoader
    {
        public static string LoadContentFromExternalTextFile(string fileName)
        {
            string output = "";
            if (File.Exists(fileName)) { output = File.ReadAllText(fileName); }
            return output;
        }
        public static List<Recipe> LoadRecipesFromExternalXMLFile(string fileName)
        {
            List<Recipe> recipes = new List<Recipe>();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            XmlNode root = xmlDocument.DocumentElement;
            XmlNodeList recipeList = root.SelectNodes("/recipes/recipe");
            XmlNodeList itemList;

            foreach (XmlElement recipe in recipeList)
            {
                Recipe temporaryRecipeToAdd = new Recipe();
                temporaryRecipeToAdd.RecipeName = recipe.GetAttribute("recipeName");
                temporaryRecipeToAdd.RecipeDescription = recipe.GetAttribute("recipeDescription");
                if (double.TryParse(recipe.GetAttribute("recipeValue"), out double value))
                {
                    temporaryRecipeToAdd.RecipeValue = value;
                }
                if (double.TryParse(recipe.GetAttribute("recipeAmount"), out double amount))
                {
                    temporaryRecipeToAdd.RecipeAmount = amount;
                }
                temporaryRecipeToAdd.RecipeAmountType = recipe.GetAttribute("recipeAmountType");

                itemList = recipe.ChildNodes;

                foreach (XmlElement item in itemList)
                {
                    Item itemToAdd = new Item();
                    itemToAdd.ItemName = item.GetAttribute("itemName");
                    itemToAdd.ItemDescription = item.GetAttribute("itemDescription");
                    if (double.TryParse(item.GetAttribute("itemValue"), out double itemValue))
                    {
                        itemToAdd.ItemValue = itemValue;
                    }
                    if (double.TryParse(item.GetAttribute("itemAmount"), out double itemAmount))
                    {
                        itemToAdd.ItemAmount = itemAmount;
                    }
                    itemToAdd.ItemAmountType = item.GetAttribute("itemAmountType");
                    temporaryRecipeToAdd.RecipeRequirements.Add(itemToAdd);
                }
                recipes.Add(temporaryRecipeToAdd);
            }
            return recipes;
        }
    }
}
