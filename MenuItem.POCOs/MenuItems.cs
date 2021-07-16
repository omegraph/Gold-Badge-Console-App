using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuItem.POCOs
{
    public class MenuItems
    {
        //private string userInputMealName;
        //private string userInputDescription;
        //private string userInputIngredients;
        //private string userInputPrice;

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItems()
        {

        }

        //public MenuItems(int mealNumber, string mealName, string description, List<string> ingredients, decimal price)
        //{
        //    MealNumber = mealNumber;
        //    MealName = mealName;
        //    Description = description;
        //    Ingredients = ingredients;
        //    Price = price;
        //}

        public MenuItems(string userInputMealName, string userInputDescription, string userInputIngredients, string userInputPrice)
        {
            //this.userInputMealName = userInputMealName;
            //this.userInputDescription = userInputDescription;
            //this.userInputIngredients = userInputIngredients;
            //this.userInputPrice = userInputPrice;
            MealName = userInputMealName;
            Description = userInputDescription;
            Ingredients = userInputIngredients.Split(',').Select(x => x.Trim()).ToList();
            Price = Convert.ToDecimal(userInputPrice);

        }
    }
}
