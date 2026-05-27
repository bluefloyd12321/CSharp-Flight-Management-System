using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManagementSystem
{
    public class Admin : User
    {
        // fields



        // properties



        // constructors
        public Admin()
        {

        }
        public Admin(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
        // methods
        public static void AdminMainMenu()
        {
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("[ 1. Flight information ]");
                Console.WriteLine("[ 2. User infomation ]");
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
                        AdminFlightInfomation();
                        break;
                    case 2:
                        Console.WriteLine("TEMP USER INFO");
                        break;
                    default:
                        Console.WriteLine("Unknown option, try again...");
                        break;
                }
            } while (LOOP);
        } // end of AdminMainMenu

        public static void AdminFlightInfomation()
        {
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                Console.WriteLine();
                Console.WriteLine("[ 1. Display all flights ]");
                Console.WriteLine("[ 2. Add a new flight ]");
                Console.WriteLine("[ 3. Remove a flight ]");
                Console.WriteLine("[ 4. Edit flight Info ]");
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
                        Console.WriteLine("Adding a new flight.");
                        // AddNewFlight();
                        break;
                    case 3:
                        Console.WriteLine("Removeing a flight.");
                        // RemoveAFlight();
                        break;
                    case 4:
                        Console.WriteLine("Editing flight infomation.");
                        // EditFlightInfo();
                        break;
                    default:
                        Console.WriteLine("Unknown option, try again...");
                        break;
                }
            } while (LOOP);
        } // end of FlightInfomation

    }
}
