using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem
{
    public class Passanger : User
    {
        // fields



        // properties



        // constructors
        public Passanger()
        {

        }
        public Passanger(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
        // methods
        public static void PassangerMainMenu()
        {
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                Console.WriteLine("[ 1. Flight information ]");
                Console.WriteLine("[ 2. Account options ]");
                Console.WriteLine("[ 0. Logout of account ]");
                mainMenuOption = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuOption)
                {
                    case 0:
                        LOOP = false;
                        Console.Clear();
                        Console.WriteLine("Logging out...");
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Flight Infomation.");
                        Console.WriteLine();
                        PassangerFlightInfomationMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Account Options.");
                        Console.WriteLine();
                        PassangerAccountOptionsMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
                        break;
                }
            } while (LOOP);
        } // end of PassangerMainMenu

        public static void PassangerFlightInfomationMenu()
        {
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                Console.WriteLine("[ 1. Display all flights ]");
                Console.WriteLine("[ 2. Display your booked flights ]");
                Console.WriteLine("[ 3. Search specific flights ]");
                Console.WriteLine("[ 4. Book a flight ]");
                Console.WriteLine("[ 5. UnBook a flight ]");
                Console.WriteLine("[ 0. Back ]");
                mainMenuOption = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuOption)
                {
                    case 0:
                        LOOP = false;
                        Console.Clear();
                        Console.WriteLine("Going back...");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Displaying all flights.");
                        Console.WriteLine();
                        // DisplayAllFlights();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Displaying your booked flights.");
                        Console.WriteLine();
                        // DisplayMyFlights();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Searching a specific flight.");
                        Console.WriteLine();
                        // SearchSpecificFlight();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Booking a flight.");
                        Console.WriteLine();
                        // BookFlight();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("UnBooking a flight.");
                        Console.WriteLine();
                        // UnBookFlight();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
                        break;
                }
            } while (LOOP);
        } // end of PassangerFlightInfomationMenu

        public static void PassangerAccountOptionsMenu()
        {
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                Console.WriteLine("[ 1. Display your details ]");
                Console.WriteLine("[ 2. Update your detials ]");
                Console.WriteLine("[ 3. Delete your account ]");
                Console.WriteLine("[ 0. Back ]");
                mainMenuOption = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuOption)
                {
                    case 0:
                        LOOP = false;
                        Console.Clear();
                        Console.WriteLine("Going back...");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Displaying your account details.");
                        Console.WriteLine();
                        // DisplayMyAccountDetails();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Updating your account details.");
                        Console.WriteLine();
                        // UpdateThisAccountDetails();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Deleting your account.");
                        Console.WriteLine();
                        // DeleteThisPassangerAccount();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
                        break;
                }
            } while (LOOP);
        } // end of PassangerAccountMenu
    }
}
