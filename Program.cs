using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Flight Reservation App";

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

        Console.WriteLine("******************************");
        Console.WriteLine("*** Flight Reservation App ***");
        Console.WriteLine("******************************");

        int mainMenuOption;
        bool LOOP = true;
        do
        {
            Console.WriteLine();
            Console.WriteLine("[ 1. Login to an account ]");
            Console.WriteLine("[ 2. Register an account ]");
            Console.WriteLine("[ 0. EXIT ]");
            mainMenuOption = Convert.ToInt32(Console.ReadLine());

            switch (mainMenuOption)
            {
                case 0:
                    LOOP = false;

                    Console.Clear();
                    Console.WriteLine("Exiting Flight Reservation App...");
                    Console.WriteLine("Thank You!");
                    break;
                case 1:
                    Console.Clear();
                    LoginToAccount(users);
                    break;
                case 2:
                    Console.Clear();
                    RegisterAnAccount(users);
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("DEBUG MODE");
                    foreach (User display in users)
                    {
                        Console.WriteLine($"{display.Username}, {display.Email}, {display.Password}");
                    }
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Unknown option, try again...");
                    break;
            }
        } while (LOOP);
    }// end of main

    public static void LoginToAccount(List<User> users)
    {
        Console.WriteLine("[ Logging Into An Account ]");
        Console.Write("Please enter your Full Name: ");
        string loginName = Console.ReadLine();
        Console.Write("Please enter your Password: ");
        string loginPassword = Console.ReadLine();
        Console.WriteLine();
        
        User searchName = users.Find(searchName => searchName.Username.Equals(loginName, StringComparison.OrdinalIgnoreCase));
        if (loginPassword == searchName.Password)
        {
            Console.Clear();
            Console.WriteLine("LOGIN SUCCESS!");
            Console.WriteLine();
            if (searchName is Admin)
            {
                Admin.AdminMainMenu();
            }
            else if (searchName is Passanger)
            {
                Passanger.PassangerMainMenu();
            }
            else
            {
                Console.WriteLine("USER ACCOUNT TYPE NOT FOUND.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("LOGIN FAIL!");
            Console.WriteLine();
        }
    }

    public static void RegisterAnAccount(List<User> users)
    {
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

        if (registerPassword == confirmPassword)
        {
            Console.Clear();
            Console.WriteLine("You are now registered!");
            
            User newUser = new Passanger(registerName, registerEmail, registerPassword);
            users.Add(newUser);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Passwords do not match, please try again...");
        }
    }

}// end of program class
