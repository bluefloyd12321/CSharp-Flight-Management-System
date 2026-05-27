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
                        Console.WriteLine("TEMP FLIGHT INFO");
                        break;
                    case 2:
                        Console.WriteLine("USER OPTIONS");
                        break;
                    default:
                        Console.WriteLine("Unknown option, try again...");
                        break;
                }
            } while (LOOP);
        }


    }
}
