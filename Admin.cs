using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            do // admins main menu loop
            {
                Console.WriteLine("[ 1. Flight Management ]");
                Console.WriteLine("[ 2. User Management ]");
                Console.WriteLine("[ 0. Logout of account ]");
                mainMenuOption = Convert.ToInt32(Console.ReadLine()); // option input

                switch (mainMenuOption)
                {
                    case 0:
                        LOOP = false; // exiting loop
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
            do // admin flight options menu
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
                        Console.WriteLine("Removing a flight...");
                        Console.WriteLine();
                        Program.flightBookings.RemoveAFlight();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Editing flight infomation...");
                        Console.WriteLine();
                        Program.flightBookings.EditFlightInfo();
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
            do // admin user management options menu
            {
                Console.WriteLine("[ 1. Display all users ]");
                Console.WriteLine("[ 2. Add a new Admin user ]");
                Console.WriteLine("[ 3. Remove a user ]");
                Console.WriteLine("[ 4. Update this admins details ]");
                Console.WriteLine("[ 5. Update another users details ]");
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
                        Console.WriteLine("Editing this admin users details...");
                        Console.WriteLine();
                        EditThisAdminsDetails();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Searching and updating another users details...");
                        Console.WriteLine();
                        SearchAndUpdateAUser();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
                        break;
                }
            } while (LOOP);
        } // end of AdminUserManagement
        public static void DisplayAllUsers() // for loop looping till all user details are displayed
        {
            for (int i = 0; i < Program.users.Count; i++)
            {
                Console.WriteLine($"User in index {i + 1} has: \n\t   Username: \t{Program.users[i].Username}\n\t      Email: \t{Program.users[i].Email}\n\t   Password: \t{Program.users[i].Password}");
                Console.WriteLine();
            }
        }
        public static void AddNewAdmin() // adding a new admin to the list of admins
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

            if (addAdminPassword == confirmAdminPassword && new EmailAddressAttribute().IsValid(addAdminEmail))
            {
                Console.Clear(); // if true, add the new admin to the admin list
                Console.WriteLine("They are now registered!");
                Console.WriteLine();
                User newAdmin = new Admin(addAdminName, addAdminEmail, addAdminPassword);
                Program.users.Add(newAdmin);
            }
            else if (addAdminPassword == confirmAdminPassword)
            {
                // Otherwise, tell the users the passwords don't match
                Console.Clear();
                Console.WriteLine("Email is invalid format, please try again...");
                Console.WriteLine();
            }
            else if (new EmailAddressAttribute().IsValid(addAdminEmail))
            {
                // Otherwise, tell the users the email format is invalid
                Console.Clear();
                Console.WriteLine("Passwords do not match, please try again...");
                Console.WriteLine();
            }
            else
            {
                // Both password and email are wrong
                Console.Clear();
                Console.WriteLine("You screwed up, please try again...");
                Console.WriteLine();
            }
        }
        public static void RemoveAUser() // searching and removing a user method
        {
            Console.Write("Which user do you want to remove: ");
            string removeUser = Console.ReadLine();

            User deleteUser = Program.users.Find(deleteUser => deleteUser.Username.Equals(removeUser, StringComparison.OrdinalIgnoreCase));
            if (deleteUser != null) // finding user then deleting them
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
        public static void EditThisAdminsDetails() // editing the details of the current admin who is logged in and is using the program
        {
            Console.Write($"Your NEW Username is: ");
            string newUsername = Console.ReadLine();
            Console.Write($"Your NEW Email is: ");
            string newEmail = Console.ReadLine();

            Console.Write($"Your NEW Password is: ");
            string newPassword = null; while (true) { ConsoleKeyInfo ck = Console.ReadKey(true); if (ck.Key != ConsoleKey.Enter) { if (ck.Key != ConsoleKey.Backspace) { newPassword += ck.KeyChar.ToString(); Console.Write("*"); } else { Console.Write("\b \b"); } } else { Console.WriteLine(); break; } }

            Console.Write($"Confirm Your NEW Password: ");
            string confirmNewPassword = null; while (true) { ConsoleKeyInfo ck = Console.ReadKey(true); if (ck.Key != ConsoleKey.Enter) { if (ck.Key != ConsoleKey.Backspace) { confirmNewPassword += ck.KeyChar.ToString(); Console.Write("*"); } else { Console.Write("\b \b"); } } else { Console.WriteLine(); break; } }

            if (newPassword == confirmNewPassword && new EmailAddressAttribute().IsValid(newEmail))
            {
                Console.Clear(); // if true, update this users details
                Console.WriteLine("Details are now updated!");
                Program.currentUser.Username = newUsername;
                Program.currentUser.Email = newEmail;
                Program.currentUser.Password = newPassword;
                Console.WriteLine();
            }
            else if (newPassword == confirmNewPassword)
            {
                // Otherwise, tell the users the passwords don't match
                Console.Clear();
                Console.WriteLine("Email is invalid format, please try again...");
                Console.WriteLine();
            }
            else if (new EmailAddressAttribute().IsValid(newEmail))
            {
                // Otherwise, tell the users the email format is invalid
                Console.Clear();
                Console.WriteLine("Passwords do not match, please try again...");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You screwed up, please try again...");
                Console.WriteLine();
            }
        }
        public static void SearchAndUpdateAUser() // search and update a users details
        {
            Console.Write("Which user do you want to update: ");
            string searchUser = Console.ReadLine();

            User updateUser = Program.users.Find(updateUser => updateUser.Username.Equals(searchUser, StringComparison.OrdinalIgnoreCase));
            if (updateUser != null) // if a user is found...
            {
                Console.Clear(); // entering the new details
                Console.WriteLine("User found, please enter the new users details...");
                Console.WriteLine();
                Console.Write($"The NEW Username is: ");
                string newUsername = Console.ReadLine();
                Console.Write($"The NEW Email is: ");
                string newEmail = Console.ReadLine();

                Console.Write($"The NEW Password is: ");
                string newPassword = null; while (true) { ConsoleKeyInfo ck = Console.ReadKey(true); if (ck.Key != ConsoleKey.Enter) { if (ck.Key != ConsoleKey.Backspace) { newPassword += ck.KeyChar.ToString(); Console.Write("*"); } else { Console.Write("\b \b"); } } else { Console.WriteLine(); break; } }

                Console.Write($"Confirm the NEW Password: ");
                string confirmNewPassword = null; while (true) { ConsoleKeyInfo ck = Console.ReadKey(true); if (ck.Key != ConsoleKey.Enter) { if (ck.Key != ConsoleKey.Backspace) { confirmNewPassword += ck.KeyChar.ToString(); Console.Write("*"); } else { Console.Write("\b \b"); } } else { Console.WriteLine(); break; } }
                
                if (newPassword == confirmNewPassword && new EmailAddressAttribute().IsValid(newEmail))
                {
                    Console.Clear(); // if password and email are valid... update user details
                    Console.WriteLine("Details are now updated!");
                    updateUser.Username = newUsername;
                    updateUser.Email = newEmail;
                    updateUser.Password = newPassword;
                }
                else if (newPassword == confirmNewPassword)
                {
                    // Otherwise, tell the users the passwords don't match
                    Console.Clear();
                    Console.WriteLine("Email is invalid format, please try again...");
                }
                else if (new EmailAddressAttribute().IsValid(newEmail))
                {
                    // Otherwise, tell the users the email format is invalid
                    Console.Clear();
                    Console.WriteLine("Passwords do not match, please try again...");
                }
                else
                {
                    Console.Clear(); // this runs when the user hasnt inputted a valid email AND passwords dont match
                    Console.WriteLine("You screwed up, please try again...");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Account not found.");
            }
            Console.WriteLine();
        }
    }// end of class
}
