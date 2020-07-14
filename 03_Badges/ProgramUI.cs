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
            Console.WriteLine("Any other doors y/n)?");
            string moreDoors = Console.ReadLine();
            if (moreDoors == "y")
            {

            }
        }
        void ShowAllBadges()
        {
            Console.Clear();
            //get contents from Queue 
            Console.WriteLine(" ClaimID    " +
             " Type      " +
             "Description       " +
             "Amount     " +
             "DateOfAccident     " +
             "DateOfClaim        " +
             "IsValid     ");
            Console.WriteLine("              ");  // blank line between
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        void DisplayContent()
        {
           //Console.WriteLine($"   {content.ClaimId}        " +
           //     $" {content.ClaimType}    " +
           //     $" {content.ClaimDescription}  " +
           //     $" ${String.Format("{0:0.00}", content.ClaimAmount)}     " +
           //     $"  {content.DateOfIncident:d}     " +
            //    $"  {content.DateOfClaim.Date:d}    " +
           //     $"  {content.IsValid}     ");
        }
        void EditBadge()
        {
        Console.Clear();
        Console.WriteLine();
        }
    }  
}
