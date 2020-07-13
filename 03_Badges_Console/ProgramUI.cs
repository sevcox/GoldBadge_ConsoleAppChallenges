using _03_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Console
{
    public class ProgramUI
    {
        private readonly BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedDictionary();
            RunMenu();
        }
        public void RunMenu()
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
                        break;
                    case "3":
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
            Badge newBadge = new Badge();
            Console.WriteLine("1. Add a Badge \n" +
                "\t What is the number on the badge: ");
            int userNewNumberInput = Convert.ToInt32(Console.ReadLine());
            userNewNumberInput = newBadge.Number;
            Console.WriteLine("List a door that it needs access to: ");
            string userNewDoorAccess = Console.ReadLine();
            newBadge.DoorAccess.Add(userNewDoorAccess);
            Console.WriteLine("Any other doors(y/n)?");
            string userYOrN = Console.ReadLine();
            while (userYOrN.ToLower() == "y")
            {
                Console.WriteLine("List a door that it needs access to: ");
                string userAnotherDoorAccess = Console.ReadLine();
                newBadge.DoorAccess.Add(userAnotherDoorAccess);
                Console.WriteLine("Any other doors(y/n)?");
            }
            _badgeRepo.AddBadgeToDictionary(newBadge);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
        public void EditBadge()
        {
            Console.WriteLine("2. Edit a Badge \n" +
                "\t What is the badge number you would like to update? ");
            int userBadgeNumber = Convert.ToInt32(Console.ReadLine());
            
        }
        public void SeedDictionary()
        {
            //Badge One
            Badge badgeOne = new Badge(12345);
            badgeOne.DoorAccess.Add("A7");
            _badgeRepo.AddBadgeToDictionary(badgeOne);
            //Badge Two
            Badge badgeTwo = new Badge(22345);
            badgeTwo.DoorAccess.Add("A1");
            badgeTwo.DoorAccess.Add("A4");
            badgeTwo.DoorAccess.Add("B1");
            badgeTwo.DoorAccess.Add("B2");
            _badgeRepo.AddBadgeToDictionary(badgeTwo);
            //Badge Three
            Badge badgeThree = new Badge(32345);
            badgeThree.DoorAccess.Add("A4");
            badgeThree.DoorAccess.Add("A5");
            _badgeRepo.AddBadgeToDictionary(badgeThree);

        }
    }
}
