using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
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
                        Console.WriteLine("User management...");
                        Console.WriteLine();
                        AdminUserManagement();
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
                        Program.flightBookings.DisplayAllFlights();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Adding a new flight...");
                        Console.WriteLine();
                        Program.flightBookings.AddNewFlight();
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


        public static void AdminUserManagement()
        {
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                Console.WriteLine("[ 1. Display all users ]");
                Console.WriteLine("[ 2. Add a new Admin user ]");
                Console.WriteLine("[ 3. Remove a user ]");
                Console.WriteLine("[ 4. Update a users details ]");
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
                        Console.WriteLine("Displaying all users...");
                        Console.WriteLine();
                        DisplayAllUsers();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Adding a new user...");
                        Console.WriteLine();
                        AddNewAdmin();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Removeing a user...");
                        Console.WriteLine();
                        RemoveAUser();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Editing a users details...");
                        Console.WriteLine();
                        // EditAUsersDetails();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
                        break;
                }
            } while (LOOP);
        } // end of AdminUserManagement
        public static void DisplayAllUsers()
        {
            for (int i = 0; i < Program.users.Count; i++)
            {
                Console.WriteLine($"User in index {i + 1} has: \n\t   Username: \t{Program.users[i].Username}\n\t      Email: \t{Program.users[i].Email}\n\t   Password: \t{Program.users[i].Password}");
                Console.WriteLine();
            }
        }
        public static void AddNewAdmin()
        {
            Console.Clear();
            Console.WriteLine("[ Registering A New Admin Account Account ]");
            Console.Write("Please enter the Full Name: ");
            string addAdminName = Console.ReadLine();
            Console.Write("Please enter the Email: ");
            string addAdminEmail = Console.ReadLine();
            Console.Write("Please enter the Password: ");
            string addAdminPassword = null; while (true) { ConsoleKeyInfo ck = Console.ReadKey(true); if (ck.Key != ConsoleKey.Enter) { if (ck.Key != ConsoleKey.Backspace) { addAdminPassword += ck.KeyChar.ToString(); Console.Write("*"); } else { Console.Write("\b \b"); } } else { Console.WriteLine(); break; } }
            Console.Write("Please confirm the Password: ");
            string confirmAdminPassword = null; while (true) { ConsoleKeyInfo ck = Console.ReadKey(true); if (ck.Key != ConsoleKey.Enter) { if (ck.Key != ConsoleKey.Backspace) { confirmAdminPassword += ck.KeyChar.ToString(); Console.Write("*"); } else { Console.Write("\b \b"); } } else { Console.WriteLine(); break; } }

            if (addAdminPassword == confirmAdminPassword)
            {
                Console.Clear();
                Console.WriteLine("They are now registered!");
                Console.WriteLine();
                User newAdmin = new Admin(addAdminName, addAdminEmail, addAdminPassword);
                Program.users.Add(newAdmin);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Passwords do not match, please try again...");
                Console.WriteLine();
            }
        }
        public static void RemoveAUser()
        {
            Console.Write("Which user do you want to remove: ");
            string removeUser = Console.ReadLine();
            
            User deleteUser = Program.users.Find(deleteUser => deleteUser.Username.Equals(removeUser, StringComparison.OrdinalIgnoreCase));
            if (deleteUser != null)
            {
                Program.users.Remove(deleteUser);
                Console.WriteLine("Account has been removed.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
            Console.WriteLine();
        }

        

    }// end of class
}
