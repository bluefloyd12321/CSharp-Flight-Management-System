using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementSystem;

class Program // start of program
{
    // Creates a global booking class that can be accessed anywhere through Program.flightBookings
    public static Booking flightBookings = new Booking();
    // Creates a variable that holds the current user so we can manipulate the current user information from anywhere
    // Is it the most elegant or safe? Probably not. But it works so ¯\_(ツ)_/¯
    public static User currentUser = null;

    public static List<User> users = new List<User>();

    public static bool MegaExit = false;

    static void Main(string[] args)
    {
        // Sets window title
        Console.Title = "Flight Reservation App";

        // Defines a list for storing users and some test users. Will delete those later
        User debugAdmin = new Admin("admin", "DEBUG.ADMIN@gmail.com", "password");
        User debugPassanger = new Passanger("user", "DEBUG.USER@gmail.com", "password");
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
        Console.Clear();
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
                case 9:
                    User.RR();
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
        string loginPassword = null;
        while (true)
        {
            //Store the keys entered by the user, and do not display characters in the entered position
            ConsoleKeyInfo ck = Console.ReadKey(true);

            //Determine whether the user pressed the Enter key
            if (ck.Key != ConsoleKey.Enter)
            {
                if (ck.Key != ConsoleKey.Backspace)
                {
                    //Store the characters entered by the user into a string
                    loginPassword += ck.KeyChar.ToString();
                    //Replace the characters entered by the user with *
                    Console.Write("*");
                }
                else
                {
                    //Delete wrong characters
                    Console.Write("\b \b");
                }
            }
            else
            {
                Console.WriteLine();
                break;
            }
        }
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
                    currentUser = null;
                }
                else if (searchName is Passanger)
                {
                    currentUser = searchName;
                    Passanger.PassangerMainMenu();
                    currentUser = null;

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
            }
        }
        else
        {
            // If the user wasn't found, tell the user
            Console.Clear();
            Console.WriteLine($"Sorry, {loginName} not found in users");
        }
        Program.MegaExit = false;
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
        string registerPassword = null;
        while (true)
        {
            //Store the keys entered by the user, and do not display characters in the entered position
            ConsoleKeyInfo ck = Console.ReadKey(true);

            //Determine whether the user pressed the Enter key
            if (ck.Key != ConsoleKey.Enter)
            {
                if (ck.Key != ConsoleKey.Backspace)
                {
                    //Store the characters entered by the user into a string
                    registerPassword += ck.KeyChar.ToString();
                    //Replace the characters entered by the user with *
                    Console.Write("*");
                }
                else
                {
                    //Delete wrong characters
                    Console.Write("\b \b");
                }
            }
            else
            {
                Console.WriteLine();
                break;
            }
        }
        Console.Write("Please confirm your Password: ");
        string confirmPassword = null;
        while (true)
        {
            //Store the keys entered by the user, and do not display characters in the entered position
            ConsoleKeyInfo ck = Console.ReadKey(true);

            //Determine whether the user pressed the Enter key
            if (ck.Key != ConsoleKey.Enter)
            {
                if (ck.Key != ConsoleKey.Backspace)
                {
                    //Store the characters entered by the user into a string
                    confirmPassword += ck.KeyChar.ToString();
                    //Replace the characters entered by the user with *
                    Console.Write("*");
                }
                else
                {
                    //Delete wrong characters
                    Console.Write("\b \b");
                }
            }
            else
            {
                Console.WriteLine();
                break;
            }
        }

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
