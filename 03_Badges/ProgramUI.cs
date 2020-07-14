using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    class ProgramUI
    {
        BadgeRepository _repo = new BadgeRepository(); //just like when our ProgramUI is instantiated, One field inside our _repo are instantiated, and not disposed of until this ProgramUI class is disposed once our ConsoleApp stops running
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
                    "Choose a menu item: \n" +
                    "1. Add a badge \n" +
                    "2. Edit a badge \n" +
                    "3. List all badges \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        // Add new
                        EnterNewBadge();
                        break;
                    case "2":
                        //Change rooms for Badge
                        EditBadge();
                        break;
                    case "3":
                        // Show All 
                        ShowAllBadges();
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
        public void EnterNewBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the number on the badge: ");
            string numberOfBadge = Console.ReadLine();
            // make sure they entered a number
            try
            {
                int result = Int32.Parse(numberOfBadge);
            }
            catch (FormatException)
            {
                // Output: Unable to parse ''
                Console.WriteLine($"Unable to parse '{numberOfBadge}' Put in a number!");
                Console.ReadKey();
            }

            Console.WriteLine("List a door that it needs access to: ");
            string doorOne = Console.ReadLine();
            // string to build the string for dictionary
            List<string> doorLoopList = new List<string>();
            doorLoopList.Add(doorOne);
            string lineConcat = "";
            bool continueToAdd = true;
            while (continueToAdd)
            {
                Console.WriteLine("Any other doors y/n)?");
                string moreDoors = Console.ReadLine();
                if (moreDoors == "y")
                {
                    Console.WriteLine("List a door that it needs access to: ");
                    string doorNext = Console.ReadLine();
                    doorLoopList.Add(doorNext);
                }
                else
                {
                    foreach (string doorEntry in doorLoopList)
                    {
                        // put comma between doors
                        if (lineConcat != "")
                        {
                            string lineComma = (lineConcat + ",");
                            lineConcat = lineComma;
                        }
                        // add door to string
                        string line = (lineConcat + doorEntry);
                        lineConcat = line;
                    }
                    continueToAdd = false;
                }

            }
            int intBadge = Int32.Parse(numberOfBadge);
            _repo.AddBadge(intBadge, lineConcat);
        }
        void ShowAllBadges()
        {
            Console.Clear();
            Console.WriteLine(" Badge #         " +
             "Door Access");
            //get contents dictionary
            DisplayContent();
            Console.WriteLine("              ");  // blank line between
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        void DisplayContent()
        {
            int badgeCount = _repo.GetBadgeCount();
            for (int i = 0; i < badgeCount; i++)
            {
                int actualBadge =_repo.GetBadge(i);
                string roomString = _repo.GetBadgeRooms(actualBadge);
                Console.WriteLine($" {actualBadge}            " +
                $" {roomString}    ");
            }
        }
        void EditBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the badge number to update? ");
            string numberOfBadge = Console.ReadLine();
            // make sure they entered a number
            try
            {
                int result = Int32.Parse(numberOfBadge);
            }
            catch (FormatException)
            {
                // Output: Unable to parse ''
                Console.WriteLine($"Unable to parse '{numberOfBadge}' Put in a number!");
                Console.ReadKey();
            }
            int intBadge = Int32.Parse(numberOfBadge);
            string currentDoors = _repo.GetBadgeRooms(intBadge);
            Console.WriteLine($"{numberOfBadge}  has access to {currentDoors} \n");
            Console.WriteLine("What would you like to do? \n" +
                "     1. Remove a door \n" +
                "     2. Add a door ");
           
            string userSelect = Console.ReadLine();
            switch (userSelect)
            {
                case "1":
                    // remove door
                    string lessDoors = RemoveDoorFromString(currentDoors);
                    _repo.RemoveBadge(intBadge);
                    _repo.AddBadge(intBadge, lessDoors);
                    string newDoors = _repo.GetBadgeRooms(intBadge);
                    Console.WriteLine($"{numberOfBadge}  has access to {newDoors} \n");
                    Console.ReadKey();
                    break;
                case "2":
                    //Add door
                    string moreDoors = AddDoorToString(currentDoors);
                    _repo.RemoveBadge(intBadge);
                    _repo.AddBadge(intBadge, moreDoors);
                    Console.WriteLine($"{numberOfBadge}  has access to {moreDoors} \n");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("You did not make a valid choice. \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
        string RemoveDoorFromString(string currentDoors)
        {
            Console.WriteLine("What door would you like to remove? ");
            string doorOut = Console.ReadLine();
            List<string> doorsBefore = currentDoors.Split(',').ToList();
            doorsBefore.Remove(doorOut);
            string lessDoors = string.Join(",", doorsBefore);
            return (lessDoors);

        }
        string AddDoorToString(string currentDoors)
        {
            Console.WriteLine("What door would you like to add? ");
            string doorNext = Console.ReadLine();
            // string to build the string for dictionary
            string lineConcat = currentDoors;
            // put comma between doors
            string lineComma = (lineConcat + ",");
            lineConcat = lineComma;
            // add door to string
            string line = (lineConcat + doorNext);
            lineConcat = line;
            return (lineConcat);
        }
    }
}
