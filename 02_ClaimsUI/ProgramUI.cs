using _02_Claims;
using _02_ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    class ProgramUI
    {
        ClaimsRepository _repo = new ClaimsRepository(); //just like when our ProgramUI is instantiated, One field inside our _repo are instantiated, and not disposed of until this ProgramUI class is disposed once our ConsoleApp stops running
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
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        // Show All 
                        ShowAllClaims();
                        break;
                    case "2":
                        //Next claim in Queue
                        NextClaimIn();
                        break;
                    case "3":
                        // Add new
                        EnterNewClaim();
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
        private void ShowAllClaims()
        {
            Console.Clear();
            //get content
            List<Claim> listOfContent = _repo.GetContents();
            // iterate thru collection
            // made out of Menu Items 
            foreach (Claim contentVariable in listOfContent)
            {
                DisplayContent(contentVariable);
                Console.WriteLine("----------------------------");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayContent(Claim content)
        {
            Console.WriteLine($" {content.ClaimId}       " +
                $"  {content.ClaimType}      " +
                $"  {content.ClaimDescription}      " +
                $"  {content.DateOfIncident}      " +
                $"  {content.DateOfClaim}      " +
                $"  {content.IsValid}     ");
        }
        private void NextClaimIn()
        {

        }
        private void EnterNewClaim()
        {

        }
    }
}

