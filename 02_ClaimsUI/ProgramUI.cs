using _02_Claims;
using _02_ClaimsRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsUI
{
    class ProgramUI
    {
        ClaimsRepository _repo = new ClaimsRepository(); //just like when our ProgramUI is instantiated, One field inside our _repo are instantiated, and not disposed of until this ProgramUI class is disposed once our ConsoleApp stops running
        Queue<int> idNumber = new Queue<int>(); //Queue defined here because I could not get it to work any other way
        
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
                    "1. See all claims (in Queue)\n" +
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
            //get contents from Queue 
            Console.WriteLine(" ClaimID    " +
             " Type      " +
             "Description       " +
             "Amount     " +
             "DateOfAccident     " +
             "DateOfClaim        " +
             "IsValid     ");
            ReadQueueDisplay();
            Console.WriteLine("              ");  // blank line between
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DisplayContent(Claim content)
        {
            Console.WriteLine($"   {content.ClaimId}        " +
                $" {content.ClaimType}    " +
                $" {content.ClaimDescription}  " +
                $" ${String.Format("{0:0.00}",content.ClaimAmount)}     " +
                $"  {content.DateOfIncident:d}     " +
                $"  {content.DateOfClaim.Date:d}    " +
                $"  {content.IsValid}     ");
        }
        private void NextClaimIn()
        {
            Console.Clear();
            int nextToGo = idNumber.Peek();
            Claim content = _repo.GetContentByClaimId(nextToGo);
            Console.WriteLine($"ClaimID: {content.ClaimId} \n" +
                $"Type: {content.ClaimType} \n" +
                $"Description: {content.ClaimDescription} \n" +
                $"Amount: ${String.Format("{0:0.00}", content.ClaimAmount)} \n" +
                $"DateOfIncident: {content.DateOfIncident:d} \n" +
                $"DateOfClaim: {content.DateOfClaim.Date:d} \n" +
                $"IsValid {content.IsValid} \n");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string removeId = Console.ReadLine();
            if (removeId == "y")
            {
                RemoveClaimQueue();
            }
        }
        private void EnterNewClaim()
        {
            Console.Clear();
            Claim content = new Claim();
            // claim id - integer that is used as lookup key
            Console.WriteLine("Enter the claim id (numeric): ");
            string claimNumber = Console.ReadLine();
            try
            {
                int result = Int32.Parse(claimNumber);
                content.ClaimId = result;
            }
            catch (FormatException)
            {
                // Output: Unable to parse ''
                Console.WriteLine($"Unable to parse '{claimNumber}' Put in a number!");
                Console.ReadKey();
            }
            // Claim Type is enum
            Console.WriteLine("Enter the claim type: \n" +
                "1) Car \n" +
                "2) Home \n" +
                "3) Theft ");
            string typeString = Console.ReadLine();
            switch (typeString)
            {
                case "1":
                    content.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    content.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    content.ClaimType = ClaimType.Theft;
                    break;
            }
            // Description string
            Console.WriteLine("Enter the claim description: ");
            content.ClaimDescription = Console.ReadLine();
            // Amount - double
            Console.WriteLine("Enter amount of Damage (number with 2 decimal places): ");
            string amount = Console.ReadLine();
            content.ClaimAmount = Convert.ToDouble(amount);
            // Date of Incident - DateTime
            Console.WriteLine("Enter the date of Incident (MM/DD/YYYY): ");
            string dateOfIncident = Console.ReadLine();
            content.DateOfIncident = DateTime.Parse(dateOfIncident);
            // Date of Claim - DateTime
            Console.WriteLine("Enter the date of Claim (MM/DD/YYYY): ");
            string dateOfClaim = Console.ReadLine();
            content.DateOfClaim = DateTime.Parse(dateOfClaim);
            // Output: claim status
            if (content.IsValid == true)
            {
                Console.WriteLine("This claim is Valid \n" +
                    "Press enter to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("This claim is NOT Valid \n" +
                    "Press enter to continue");
                Console.ReadKey();
            }
            // call repository add claim method
            _repo.AddClaim(content);
            AddClaimQueue(content.ClaimId);
        }
        //Queue methods
        public void AddClaimQueue(int identifyNumber)
        {
            idNumber.Enqueue(identifyNumber);
        }
        public void RemoveClaimQueue()
        {
            idNumber.Dequeue();
        }
        public void PeekClaimQueue()
        {
            idNumber.Peek();
        }
        public void ReadQueueDisplay()
        {
            foreach (int number in idNumber)
            {
                Claim information = _repo.GetContentByClaimId(number);
                DisplayContent(information);
            }
        }
    }
}

