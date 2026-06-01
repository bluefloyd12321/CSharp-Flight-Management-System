using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementSystem;

class Program
{
    public static Booking flightBookings = new Booking();
    public static User currentUser;

    static void Main(string[] args)
    {
        // Sets window title
        Console.Title = "Flight Reservation App";

        // Defines a list for storing users and some test users. Will delete those later
        List<User> users = new List<User>();
        User debugAdmin = new Admin("admin", "DEBUG.ACCOUNT@gmail.com", "password");
        User debugPassanger = new Passanger("user", "DEBUG.ACCOUNT@gmail.com", "password");
        users.Add(debugAdmin);
        users.Add(debugPassanger);
        User vee = new Admin("Vee McCabe", "Vee@gmail.com", "0224623917");
        User morgan = new Admin("Morgan Piper", "Morgan@gmail.com", "BlueFloyd12321");
        User damien = new Passanger("Damien Oliver", "Damien@gmail.com", "HairyDog");
        User katie = new Passanger("Katie", "Katie@gmail.com", "IDontCare");
        users.Add(vee);
        users.Add(morgan);
        users.Add(damien);
        users.Add(katie);

        // Display app title to user
        Console.WriteLine("******************************");
        Console.WriteLine("*** Flight Reservation App ***");
        Console.WriteLine("******************************");

        // Core app loop
        int mainMenuOption;
        bool LOOP = true;
        do
        {
            // Display menu options and accept uesr input
            Console.WriteLine();
            Console.WriteLine("[ 1. Register an account ]");
            Console.WriteLine("[ 2. Login to an account ]");
            Console.WriteLine("[ 0. EXIT ]");
            mainMenuOption = Convert.ToInt32(Console.ReadLine());

            switch (mainMenuOption)
            {
                // Exits the app
                case 0:
                    LOOP = false;

                    Console.Clear();
                    Console.WriteLine("Exiting Flight Reservation App...");
                    Console.WriteLine("Thank You!");
                    break;
                case 1:
                    // Sends user to the registration menu
                    Console.Clear();
                    RegisterAnAccount(users);
                    break;
                case 2:
                    // Sends user to login menu
                    Console.Clear();
                    LoginToAccount(users);
                    break;
                case 5:
                    // Special debug case. Will remove later
                    Console.Clear();
                    Console.WriteLine("DEBUG MODE");
                    foreach (User display in users)
                    {
                        Console.WriteLine($"{display.Username}, {display.Email}, {display.Password}");
                    }
                    break;
                default:
                    // Default case if user inputs an invalid option
                    Console.Clear();
                    Console.WriteLine("Unknown option, try again...");
                    break;
            }
        } while (LOOP);
    }// end of main

    // Function for loggin the user in
    public static void LoginToAccount(List<User> users)
    {
        // Display login stuffs
        Console.WriteLine("[ Logging Into An Account ]");
        Console.Write("Please enter your Full Name: ");
        string loginName = Console.ReadLine();
        Console.Write("Please enter your Password: ");
        string loginPassword = Console.ReadLine();
        Console.WriteLine();

        // Checks for the user in the users list
        User searchName = users.Find(searchName => searchName.Username.Equals(loginName, StringComparison.OrdinalIgnoreCase));
        if (searchName != null)
        {
            // If the user is found, attempt login process
            if (loginPassword == searchName.Password)
            {
                Console.Clear();
                Console.WriteLine("LOGIN SUCCESS!");
                Console.WriteLine();
                if (searchName is Admin)
                {
                    currentUser = searchName;
                    Admin.AdminMainMenu();
                }
                else if (searchName is Passanger)
                {
                    currentUser = searchName;
                    Passanger.PassangerMainMenu();

                }
                else
                {
                    Console.WriteLine("USER ACCOUNT TYPE NOT FOUND.");
                }
            }
            // Else display the login failed
            else
            {
                Console.Clear();
                Console.WriteLine("LOGIN FAIL!");
                Console.WriteLine();
            }
        }
        else
        {
            // If the user wasn't found, tell the user
            Console.WriteLine($"Sorry, {loginName} not found in users");
        }
    }

    // Function for creating a new user
    public static void RegisterAnAccount(List<User> users)
    {
        // Display menu stuffs to user
        Console.Clear();
        Console.WriteLine("[ Registering An Account ]");
        Console.Write("Please enter your Full Name: ");
        string registerName = Console.ReadLine();
        Console.Write("Please enter your Email: ");
        string registerEmail = Console.ReadLine();
        Console.Write("Please enter your Password: ");
        string registerPassword = Console.ReadLine();
        Console.Write("Please confirm your Password: ");
        string confirmPassword = Console.ReadLine();

        // Check the inputted passwords match
        if (registerPassword == confirmPassword)
        {
            // If yes, add the user to the users list
            Console.Clear();
            Console.WriteLine("You are now registered!");

            User newUser = new Passanger(registerName, registerEmail, registerPassword);
            users.Add(newUser);
        }
        else
        {
            // Otherwise, tell the users the passwords don't match
            Console.Clear();
            Console.WriteLine("Passwords do not match, please try again...");
        }
    }

}// end of program class
