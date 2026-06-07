using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightManagementSystem
{
    public class Passanger : User
    {
        // fields

        // So many fields here....... - Morgan

        // properties

        // Not seeing many properties here...... - Morgan

        // constructors
        public Passanger()
        {
            // This constructor does sooo muchhhh - Morgan
        }
        public Passanger(string username, string email, string password)
        {
            // Just sets properties, nothing fancy
            Username = username;
            Email = email;
            Password = password;
        }

        // methods
        public static void PassangerMainMenu()
        {
            // Main loop
            int mainMenuOption;
            bool LOOP = true;
            do
            {
                // Display menu options to the user
                Console.WriteLine("[ 1. Flight information ]");
                Console.WriteLine("[ 2. Account options ]");
                Console.WriteLine("[ 0. Logout of account ]");
                mainMenuOption = Convert.ToInt32(Console.ReadLine());

                switch (mainMenuOption)
                {
                    case 0:
                        // Logs the user out
                        LOOP = false;
                        Console.Clear();
                        Console.WriteLine("Logging out...");
                        break;
                    case 1:
                        // Sends passengers to the flight info menu
                        Console.Clear();
                        Console.WriteLine("Flight Infomation...");
                        Console.WriteLine();
                        PassangerFlightInfomationMenu();
                        break;
                    case 2:
                        // Sends user to passenger account options
                        Console.Clear();
                        Console.WriteLine("Account Options...");
                        Console.WriteLine();
                        PassangerAccountOptionsMenu();
                        if (Program.MegaExit = true)
                        {
                            LOOP = false;
                        }
                        break;
                    default:
                        // Default for invalid options
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
                // Display the menu options
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
                        // Goes back
                        LOOP = false;
                        Console.Clear();
                        Console.WriteLine("Going back...");
                        Console.WriteLine();
                        break;
                    case 1:
                        // Displays all available flights
                        Console.Clear();
                        Console.WriteLine("Displaying all flights...");
                        Console.WriteLine();
                        Program.flightBookings.DisplayAllFlights();
                        break;
                    case 2:
                        // Display booked flights
                        Console.Clear();
                        Console.WriteLine("Displaying your booked flights...");
                        Console.WriteLine();
                        Program.flightBookings.DisplayMyFlights();
                        break;
                    case 3:
                        // Search for flight
                        Console.Clear();
                        Console.WriteLine("Searching a specific flight...");
                        Console.WriteLine();
                        // SearchSpecificFlight();
                        break;
                    case 4:
                        // Books a flight
                        Console.Clear();
                        Console.WriteLine("Booking a flight...");
                        Console.WriteLine();
                        Program.flightBookings.BookFlight();
                        break;
                    case 5:
                        // Unbooks flight
                        Console.Clear();
                        Console.WriteLine("UnBooking a flight...");
                        Console.WriteLine();
                        Program.flightBookings.UnBookFlight();
                        break;
                    default:
                        // Default for invalid options
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
                        Console.WriteLine("Displaying your account details...");
                        Console.WriteLine();
                        DisplayMyAccountDetails();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Updating your account details...");
                        Console.WriteLine();
                        UpdateThisAccountDetails();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("ARE YOU SURE YOU WANT TO DELETE YOUR ACCOUNT?");
                        Console.WriteLine("( Yes / No )");
                        string accountDeleteConfirmation = "No";
                        accountDeleteConfirmation = Console.ReadLine();
                        if (accountDeleteConfirmation == "Yes")
                        {
                            Console.WriteLine("Deleting your account...");
                            
                            DeleteThisPassangerAccount();
                            LOOP = false;
                        }
                        else
                        {
                            Console.WriteLine("Not deleting your account...");
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Unknown option, try again...");
                        Console.WriteLine();
                        break;
                }
            } while (LOOP);
        } // end of PassangerAccountMenu
        public static void DisplayMyAccountDetails()
        {
            Console.WriteLine($"Your Username is: \t{Program.currentUser.Username}");
            Console.WriteLine($"Your Email is: \t\t{Program.currentUser.Email}");
            Console.WriteLine($"Your Password is: \t{Program.currentUser.Password}");
            Console.WriteLine();
        }
        public static void UpdateThisAccountDetails()
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
                Console.Clear();
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

        public static void DeleteThisPassangerAccount()
        {
            User deleteUser = Program.users.Find(deleteUser => deleteUser.Username.Equals(Program.currentUser.Username, StringComparison.OrdinalIgnoreCase));
            Program.users.Remove(deleteUser);
            Program.MegaExit = true;
        }

    }
}
