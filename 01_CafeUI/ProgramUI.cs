using _01_Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _01_Cafe.CafeClass;

namespace _01_CafeUI
{
    public class ProgramUI
    {
        CafeRepository _repo = new CafeRepository(); //just like when our ProgramUI is instantiated, One field inside our _repo are instantiated, and not disposed of until this ProgramUI class is disposed once our ConsoleApp stops running
        public void Run()
        {
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine(
                    "Enter the number of the option you'd like to select: \n" +
                    "1. Add new menu item content \n" +
                    "2. Remove menu item by number \n" +
                    "3. Show all menu items \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        // Add new
                        CreateNewItem();
                        //show all
                        break;
                    case "2":
                        //remove
                        RemoveMenuItem();
                        break;
                    case "3":
                        // Show All Content
                        ShowAllMenuItems();
                        break;
                    case "4":
                        //exit
                        continueToRun = false;
                        break;
                    default:
                        
                        Console.WriteLine("Please enter a valid number between 1 and 4. \n" +
                            "Press any key to continue...");
                        
                        Console.ReadKey();

                        break;
                }

            }
        }
        private void CreateNewItem()
        {
            Console.Clear();
            MenuItem content = new MenuItem();
            // title
            Console.WriteLine("Please enter the meal number: ");
            string itemNumber = Console.ReadLine();
            try
            {
                int result = Int32.Parse(itemNumber);
                Console.WriteLine(result);
                content.MealNumber = result;
            }
            catch (FormatException)
            {
                // Output: Unable to parse ''
                Console.WriteLine($"Unable to parse '{itemNumber}' Put in a number!");
                Console.ReadKey();
            }
            // MealName
            Console.WriteLine("Please enter the meal name: ");
            content.MealName = Console.ReadLine();
            // Description
            Console.WriteLine("Please enter the meal description: ");
            content.MealDescription = Console.ReadLine();
            // Ingredients - one string
            Console.WriteLine("Please enter the meal ingredients - separate by comma: ");
            content.Ingredients = Console.ReadLine();
            // Meal Price - double
            Console.WriteLine("Please enter the meal price  - two decimal places: ");
            string itemPrice = Console.ReadLine();
            content.MealPrice = Convert.ToDouble(itemPrice);
            // call repository add meal method
            _repo.AddMealToMenu(content);
        }
        private void RemoveMenuItem()
        {
            Console.WriteLine("Which Item Number would you like to remove?");
            List<MenuItem> contentList = _repo.GetContents();
            int count = 0;
            foreach (MenuItem content in contentList)
            {
                count++;
                Console.WriteLine($"{count} {content.MealNumber}");
            }
            int targetContentID = int.Parse(Console.ReadLine());
            int targetIndex = targetContentID - 1;
            if (targetIndex >= 0 && targetIndex < contentList.Count)
            {
                MenuItem desiredContent = contentList[targetIndex];
                if (_repo.DeleteExistingContent(desiredContent))
                {
                    Console.WriteLine($"{desiredContent.MealNumber}  successfully removed");
                }
                else
                {
                    Console.WriteLine($"I'm sorry.  I'm afraid I can't do that.");
                }
            }
            else
            {
                Console.WriteLine("No Content has that id");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllMenuItems()
        {
            Console.Clear();
            //get content
            List<MenuItem> listOfContent = _repo.GetContents();
            // iterate thru collection
            // made out of Menu Items 
            foreach (MenuItem contentVariable in listOfContent)
            {
                DisplayContent(contentVariable);
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayContent(MenuItem content)
        {
            Console.WriteLine($"Menu Number: {content.MealNumber} \n" +
                $"Name: {content.MealName} \n" +
                $"MealDescription: {content.MealDescription} \n" +
                $"Ingredients: {content.Ingredients} \n" +
                $"MealPrice:  {content.MealPrice} ");
        }
    }
}
