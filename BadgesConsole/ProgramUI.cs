using BadgesApp.POCOs;
using BadgesApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesConsole
{
    public class ProgramUI
    {
        private BadgesRepository _badgesRepository = new BadgesRepository();
        public void Run()
        {
            RunApplication();
            
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {

                //Security staff member options
                Console.Clear();
                Console.WriteLine("Welcome to the badging system\n" +
                    "1. Add a new badge\n" +
                    "2. Update an existing badge\n" +
                    "3. List all badges\n" +
                    "4. Close application\n");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    //Add a badge
                    case "1":
                        AddNewBadge();
                        break;

                    //Update existing badge
                    case "2":
                        UpdateBadge();
                        break;

                    //List all badges
                    case "3":
                        SeeAllbadges();
                        break;

                    //Close application
                    case "4":
                        Console.WriteLine("Goodbye!");
                        isRunning = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid Entry");
                        Console.ReadKey();
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        //Case 1: Add a new badge
        private void AddNewBadge()
        {
            Badges newBadge = new Badges();
            Dictionary<int, List<string>> badgesDictionary = _badgesRepository.GetBadgesDictionary();
            Console.Clear();
            int newBadgeNumber = 0;
            bool validBadgeNumber = false;
            Console.WriteLine("Please enter the badge number:");
            newBadgeNumber = int.Parse(Console.ReadLine());
            while (!validBadgeNumber)
            {
                bool currentNumber = badgesDictionary.ContainsKey(newBadgeNumber);
                if (currentNumber)
                {
                    Console.WriteLine("Sorry, this badge number is already in use!!!");
                    Console.WriteLine("Please enter the number on the new badge:");
                    newBadgeNumber = int.Parse(Console.ReadLine());
                    validBadgeNumber = false;
                }
                else
                {
                    validBadgeNumber = true;
                }
            }
            List<string> newDoorList = new List<string>();
            bool addDoor = true;
            while (addDoor)
            {
                Console.WriteLine($"Please enter the door name that can be access with badge number {newBadgeNumber}:");
                string door = Console.ReadLine();
                newDoorList.Add(door);
                Console.WriteLine($"Add another that can be access with badge number {newBadgeNumber} (y/n)");
                string doorAddAnswer = Console.ReadLine().ToLower();
                if (doorAddAnswer != "y")
                {
                    if (doorAddAnswer == "n")
                    {
                        addDoor = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter y or n: ");
                        doorAddAnswer = Console.ReadLine().ToLower();
                    }
                }
            }
            newBadge.BadgeID = newBadgeNumber;
            newDoorList.Sort();
            newBadge.DoorName = newDoorList;
            _badgesRepository.AddNewBadgeToList(newBadge);
            Console.WriteLine($"Badge number {newBadge.BadgeID} has been added.");
        }


        //Case 2: Ubdate existing badge
        private void UpdateBadge()
        {
            Dictionary<int, List<string>> badgesDictionary = _badgesRepository.GetBadgesDictionary();
            int updateBadgeNumber = 0;
            bool notExistBadgeNumber = true;
            while (notExistBadgeNumber)
            {
                SeeAllbadges();
                Console.WriteLine("\n\nPlease enter the badge number to update:");
                updateBadgeNumber = int.Parse(Console.ReadLine());
                if (badgesDictionary.ContainsKey(updateBadgeNumber))
                {
                    Console.Clear();
                    Console.WriteLine("That is a valid badge number");
                    notExistBadgeNumber = false;
                }
                else
                {
                    Console.WriteLine("Badge number doesn't exist, Please enter a valid number");
                }
            }
            Badges updateBadge = _badgesRepository.GetBadgesByID(updateBadgeNumber);
            List<string> updateDoorList = updateBadge.DoorName;
            bool notCompleteAdd = true;
            bool notCompleteSub = true;
            while (notCompleteAdd || notCompleteSub)
            {
                Console.WriteLine("Please select an option\n" +
                                    "1. Delete existing door\n" +
                                    "2. Add a new door\n" +
                                    "3. Return to the main menu");
                string updateUserInput = Console.ReadLine();
                switch (updateUserInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine($"Updating badge # {updateBadgeNumber}\n");
                        SeeAllDoorNames(updateBadge);
                        Console.WriteLine("Which door would you like to add.\n" +
                                           "Press enter after each door you would like to add.\n" +
                                           "Enter 'Done' when complete.\n");
                        string addDoor = Console.ReadLine();
                        string addDoorStr = "";
                        while (addDoor != "done" && addDoor != "Done")
                        {
                            bool newDoor = updateDoorList.Contains(addDoor);
                            if (!newDoor)
                            {
                                updateDoorList.Add(addDoor);
                                addDoorStr = addDoorStr + " " + addDoor;
                            }
                            addDoor = Console.ReadLine();
                        }
                        Console.WriteLine($"The following doors were added to badge {updateBadgeNumber}: {addDoorStr}");
                        notCompleteAdd = false;
                        break;

                    case "3":
                        notCompleteAdd = false;
                        notCompleteSub = false;
                        break;
                    default:
                        Console.WriteLine("Please select an option");
                        break;
                }
                updateDoorList.Sort();
                Badges updatedBadge = new Badges(updateBadgeNumber, updateDoorList);
                bool badgeSuccessUpdate = _badgesRepository.UpdateExistingBadge(updateBadgeNumber, updatedBadge);
                if (badgeSuccessUpdate)
                {
                    Console.WriteLine($"Badge #{updateBadgeNumber} was successfully updated.");
                }
                else
                {
                    Console.WriteLine("No badge was updated");
                }
            }
        }

        private void SeeAllbadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgesRepository.GetBadgesDictionary();
            Console.WriteLine("Badge #     Door Access");
            foreach (KeyValuePair<int, List<string>> entry in badgeDictionary)
            {
                string doorString = "";
                if (entry.Value.Count !=0)
                {
                    for (int i =1; i < entry.Value.Count; i++)
                    {
                        doorString = doorString + entry.Value[i - 1] + ", ";
                    }
                    doorString = doorString + entry.Value[entry.Value.Count - 1];
                }
                Console.WriteLine($"{entry.Key}     {doorString}");
            }

        }
        private void SeeAllDoorNames(Badges badge)
        {
            string doorString = "";
            if (badge.DoorName.Count != 0)
            {
                for (int i = 0; i < badge.DoorName.Count - 1; i++)
                {
                    doorString = doorString + badge.DoorName[i] + ", ";
                }

                doorString = doorString + badge.DoorName[badge.DoorName.Count - 1];
                Console.WriteLine($"{badge.BadgeID} has access to: {doorString}");
            }

        }



    }
    
}
