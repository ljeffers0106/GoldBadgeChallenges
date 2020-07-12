using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class CafeClass
    {
        
        public class MenuItem
        {
            public int MealNumber { get; set; }
            public string MealName { get; set; }
            public string MealDescription { get; set; }
            public string Ingredients { get; set; }
            public double MealPrice { get; set; }
            public MenuItem() { } 
          
            public MenuItem(int mealNumber, string mealName, string mealDescription, string ingredients, double mealPrice)
            {
                MealNumber = mealNumber;
                MealName = mealName;
                MealDescription = mealDescription;
                Ingredients = ingredients;
                MealPrice = mealPrice;
            }

        }
        
    }
}

