using ClaimApp.Repository;
using ClaimsApp.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsAppUI
{
    public class Program_UI
    {
        private ClaimRepository _claimRepository = new ClaimRepository();

        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to Komodo Claims App\n" +
                                 "1. See ALL Claims \n" +
                                 "2. Take CAre of Next Claim \n" +
                                 "3. Enter New Claim \n" +
                                 "4. Close Application\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Entry");
                        Console.ReadKey();
                        break;

                }

            }


        }
        public void SeeAllClaims()
        {
            Console.Clear();

            Queue<Claims> _listOfClaims = _claimRepository.GetClaims();

            foreach (var claims in _listOfClaims)
            {
                DisplayClaims(claims);
            }

            Console.ReadKey();

        }

        private void DisplayClaims(Claims claim)
        {
            Console.WriteLine(
                                $"ClaimID: {claim.ClaimID}\n" +
                                $"Type: {claim.ClaimType}\n" +
                                $"Description: {claim.Description}\n" +
                                $"Amount: {claim.ClaimAmount}\n" +
                                $"Date of Accident: {claim.DateOfIncident}\n" +
                                $"Date of Claim: {claim.DateOfClaim}\n" +
                                $"IsValid: {claim.IsValid}\n");
            Console.WriteLine("------------------------------------------------");


        }

        public void TakeCareOfNextClaim()
        {
            Console.Clear();
            SeeAllClaims();

            Queue<Claims> _currentInQueue = _claimRepository.GetClaims();
            var nextInQueue = _currentInQueue.Peek();

            Console.WriteLine("Here are the details for the next claim to be handled: \n" +
                $"Claim ID: {nextInQueue.ClaimID}\n" +
                $"Claim Type: {nextInQueue.ClaimType}\n" +
                $"Description: {nextInQueue.Description}\n" +
                 $"Amount: {nextInQueue.ClaimAmount}\n" +
                 $"Date of Incident: {nextInQueue.DateOfIncident}\n" +
                 $"Date of Claim: {nextInQueue.DateOfClaim}\n" +
                 $"Is valid: {nextInQueue.IsValid}\n");
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string userInput = Console.ReadLine().ToLower();

            if(userInput == "y")
            {
                _currentInQueue.Dequeue();
            }
            else
            {
                Console.Clear();
                RunApplication();
            }

        }

        public void EnterNewClaim()
        {
            Console.Clear();
            Claims newClaim = new Claims();

            Console.WriteLine("Enter the claim id:");
            newClaim.ClaimID = Console.ReadLine();

            Console.WriteLine("Enter the claim type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string userInputType = Console.ReadLine();

            Console.WriteLine("Enter the claim description:");
            newClaim.Description = Console.ReadLine();

            Console.WriteLine("Enter the claim amount: $");
            newClaim.ClaimAmount = Console.ReadLine();

            Console.WriteLine("Enter the date of incident:");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the date of claim:");
            newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());
                        
           var difference = (newClaim.DateOfClaim - newClaim.DateOfIncident).TotalDays;
            Console.WriteLine("The claim is made "+ difference + " after the date of the incident");
            if (difference <= 30)
            {
                Console.WriteLine("Claim is valid");

                _claimRepository.AddClaim(newClaim);
            }
            else
                Console.WriteLine("Claim is not valid!");
            Console.ReadKey();
            Console.Clear();

        }



    }
}
