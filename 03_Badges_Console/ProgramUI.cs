using _03_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    public class ProgramUI
    {
        protected readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedDictionary();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Menu \n" +
                    "\t Hello Security Admin, what would you like to do? \n" +
                    "\t 1. Add a badge. \n" +
                    "\t 2. Edit a badge. \n" +
                    "\t 3.List all badges. \n" +
                    "\t 4.Exit");
                string userStartInput = Console.ReadLine();
                switch (userStartInput)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ShowAllBadges();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number between 1 and 4 \n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void AddBadge()
        {
            Console.Clear();

            Badge newBadge = new Badge();
            List<string> newBadgeDoors = new List<string>();

            Console.WriteLine("1. Add a Badge \n" +
                "\t What is the number on the badge: ");
            newBadge.Number = Convert.ToInt32(Console.ReadLine());
            bool continueToAsk = true;
            while (continueToAsk)
            {
                Console.WriteLine("List a door that it needs access to: ");
                string userNewDoorAccess = Console.ReadLine();
                newBadgeDoors.Add(userNewDoorAccess);
                Console.WriteLine("Any other doors(y/n)?");
                string userYOrN = Console.ReadLine();
                if (userYOrN.ToLower() == "y")
                {
                    continueToAsk = true;
                }
                else if (userYOrN.ToLower() == "n")
                {
                    continueToAsk = false;
                    break;
                }
            }
            newBadge.DoorAccess = newBadgeDoors;
            _badgeRepo.AddBadgeToDictionary(newBadge);
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();

        }
        public void EditBadge()
        {
            //need to handle if door removed = 0
            Console.Clear();
            Console.WriteLine("2. Edit a Badge \n" +
                "\t What is the badge number you would like to update? ");
            int userBadgeNumber = Convert.ToInt32(Console.ReadLine());
            Badge oldBadge = _badgeRepo.GetBadgeByNumber(userBadgeNumber);
            if (oldBadge.DoorAccess.Count == 0)
            {
                Console.WriteLine("{0} has access to no doors.", oldBadge.Number);
            }
            else if ( oldBadge.DoorAccess.Count < 1)
            {
                Console.WriteLine("{0} has access to doors {1}", oldBadge.Number, oldBadge.DisplayDoors(oldBadge.DoorAccess));
            }
            else if (oldBadge.DoorAccess.Count == 1)
            {
                Console.WriteLine("{0} has access to door {1}", Convert.ToString(oldBadge.Number), oldBadge.DisplayDoors(oldBadge.DoorAccess));
            }
            else
            {
                Console.WriteLine("Invalid response. Please enter a valid badge number to update.");
            }
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("What would you like to do? \n" +
                  "\t 1. Remove a door. \n" +
                  "\t 2. Add a door. \n" +
                  "\t 3. Return to main menu.");
                string userInput = Console.ReadLine();
                switch (userInput.ToLower())
                {
                    case "1":
                    case "remove a door":
                        Console.WriteLine("Which door would you like to remove? ");
                        string userDoorInput = Console.ReadLine();
                        bool wasRemoved = _badgeRepo.RemoveADoorFromBadge(oldBadge, userDoorInput);
                        if(wasRemoved == true)
                        {
                            Console.WriteLine("Door was removed.");
                        }
                        else if (wasRemoved == false)
                        {
                            Console.WriteLine("Door was not successfully removed");
                        }
                        else
                        {
                            Console.WriteLine("An error has occured. Return to the main menu to try again.");
                        }

                        if (oldBadge.DoorAccess.Count < 1)
                        {
                            Console.WriteLine("{0} has access to doors {1}", Convert.ToString(oldBadge.Number), oldBadge.DisplayDoors(oldBadge.DoorAccess));
                        }
                        else if (oldBadge.DoorAccess.Count == 1)
                        {
                            Console.WriteLine("{0} has access to door {1}", Convert.ToString(oldBadge.Number), oldBadge.DisplayDoors(oldBadge.DoorAccess));
                        }
                        else
                        {
                            Console.WriteLine("Invalid response. Please enter a valid door number to add.");
                        }
                        break;
                    case "2":
                    case "add a door":
                        Console.WriteLine("\n Enter in the door number you would like to add: ");
                        string userNewDoorInput = Console.ReadLine();
                        _badgeRepo.AddADoorToBadge(oldBadge, userNewDoorInput);
                        if (oldBadge.DoorAccess.Count > 1)
                        {
                            Console.WriteLine("{0} has access to doors {1}", Convert.ToString(oldBadge.Number), oldBadge.DisplayDoors(oldBadge.DoorAccess));
                        }
                        else if (oldBadge.DoorAccess.Count == 1)
                        {
                            Console.WriteLine("{0} has access to door {1}", Convert.ToString(oldBadge.Number), oldBadge.DisplayDoors(oldBadge.DoorAccess));
                        }
                        else
                        {
                            Console.WriteLine("Invalid response. Please enter a valid door number to add.");
                        }
                        break;
                    case "3":
                    case "return to main menu":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response. Attempt was unsuccessful");
                        break;
                }
            }
            _badgeRepo.AddBadgeToDictionary(oldBadge);
            Console.WriteLine(" \n Press any key to continue...");
            Console.ReadKey();
        }
        private void ShowAllBadges()
        {
            Console.Clear();
            var header = String.Format("{0,-10}{1,20}\n", "Badge #", "Door Access");
            Console.WriteLine(header);
            Dictionary<int, Badge> idAndBadge = _badgeRepo.ReturnBadgeDictionary();
            foreach (KeyValuePair<int, Badge> keyValuePair in idAndBadge)
            {
                DisplayAllBadges(keyValuePair.Value);
            }
            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();

        }
        private void DisplayAllBadges(Badge badge)
        {
            var output = String.Format("{0,-10}{1,20}", badge.Number, badge.DisplayDoorsWithComma(badge.DoorAccess));
            Console.WriteLine(output);
        }
        public void SeedDictionary()
        {
            //Badge One
            List<string> badgeOneDoors = new List<string>();
            badgeOneDoors.Add("A7");
            Badge badgeOne = new Badge(12345, badgeOneDoors);
            _badgeRepo.AddBadgeToDictionary(badgeOne);
            //Badge Two
            List<string> badgeTwoDoors = new List<string>();
            badgeTwoDoors.Add("A1");
            badgeTwoDoors.Add("A4");
            badgeTwoDoors.Add("B1");
            badgeTwoDoors.Add("B2");
            Badge badgeTwo = new Badge(22345, badgeTwoDoors);
            _badgeRepo.AddBadgeToDictionary(badgeTwo);
            //Badge Three
            List<string> badgeThreeDoors = new List<string>();
            badgeThreeDoors.Add("A4");
            badgeThreeDoors.Add("A5");
            Badge badgeThree = new Badge(32345, badgeThreeDoors);
            _badgeRepo.AddBadgeToDictionary(badgeThree);
        }
    }
}
