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
                        Console.WriteLine("TEMP FLIGHT INFO");
                        break;
                    case 2:
                        Console.WriteLine("TEMP USER INFO");
                        break;
                    default:
                        Console.WriteLine("Unknown option, try again...");
                        break;
                }
            } while (LOOP);
        }



    }
}
