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
                Console.WriteLine("[ 1. Flight Management ]");
                Console.WriteLine("[ 2. User Management ]");
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
                        Console.WriteLine("Admin flight management...");
                        Console.WriteLine();
                        AdminFlightInfomation();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("TEMP User management...");
                        Console.WriteLine();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
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
                        Console.Clear();
                        Console.WriteLine("Going back...");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Displaying all flights...");
                        Console.WriteLine();
                        // DisplayAllFlights();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Adding a new flight...");
                        Console.WriteLine();
                        // AddNewFlight();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Removeing a flight...");
                        Console.WriteLine();
                        // RemoveAFlight();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Editing flight infomation...");
                        Console.WriteLine();
                        // EditFlightInfo();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
                        break;
                }
            } while (LOOP);
        } // end of FlightInfomation

    }
}
