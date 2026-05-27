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
                Console.WriteLine();
                Console.WriteLine("[ 1. Flight information ]");
                Console.WriteLine("[ 2. Account options ]");
                Console.WriteLine("[ 0. Logout of account ]");
                mainMenuOption = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuOption)
                {
                    case 0:
                        LOOP = false;
                        Console.WriteLine();
                        Console.WriteLine("Logging out...");
                        break;
                    case 1:
                        PassangerFlightInfomation();
                        break;
                    case 2:
                        Console.WriteLine("TEMP Account Options.");
                        break;
                    default:
                        Console.WriteLine("Unknown option, try again...");
                        break;
                }
            } while (LOOP);
        } // end of PassangerMainMenu

        public static void PassangerFlightInfomation()
        {
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("[ 1. Display all flights ]");
                Console.WriteLine("[ 2. Display your booked flights ]");
                Console.WriteLine("[ 3. Search specific flights ]");
                Console.WriteLine("[ 4. Book a flight ]");
                Console.WriteLine("[ 4. UnBook a flight ]");
                Console.WriteLine("[ 0. Back ]");
                mainMenuOption = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuOption)
                {
                    case 0:
                        LOOP = false;
                        break;
                    case 1:
                        Console.WriteLine("Displaying all flights.");
                        // DisplayAllFlights();
                        break;
                    case 2:
                        Console.WriteLine("Displaying your booked flights.");
                        // DisplayMyFlights();
                        break;
                    case 3:
                        Console.WriteLine("Searching a specific flight.");
                        // SearchSpecificFlight();
                        break;
                    case 4:
                        Console.WriteLine("Booking a flight.");
                        // BookFlight();
                        break;
                    case 5:
                        Console.WriteLine("UnBooking a flight.");
                        // UnBookFlight();
                        break;
                    default:
                        Console.WriteLine("Unknown option, try again...");
                        break;
                }
            } while (LOOP);
        } // end of PassangerFlightInfomation

    }
}
