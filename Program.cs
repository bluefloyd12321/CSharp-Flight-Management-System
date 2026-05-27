using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "*** Flight Reservation App ***";

        Console.WriteLine("******************************");
        Console.WriteLine("*** Flight Reservation App ***");
        Console.WriteLine("******************************");

        List<User> users = new List<User>();
        User a = new Admin("a", "DEBUG.ACCOUNT@gmail.com", "1");
        User vee = new Admin("Vee McCabe", "Vee@gmail.com", "0224623917");
        User morgan = new Admin("Morgan Piper", "Morgan@gmail.com", "BlueFloyd12321");
        User damien = new Passanger("Damien Oliver", "Damien@gmail.com", "HeiryDog");
        User katie = new Passanger("Katie", "Katie@gmail.com", "IDontCare");
        users.Add(a);
        users.Add(vee);
        users.Add(morgan);
        users.Add(damien);
        users.Add(katie);

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
                    break; 
                case 1:
                    LoginToAccount(users);
                    break;
                case 2:
                    RegisterAnAccount(users);
                    break;
                case 5:
                    Console.WriteLine();
                    Console.WriteLine("DEBUG MODE");
                    foreach (User display in users)
                    {
                        Console.WriteLine($"{display.Username}, {display.Email}, {display.Password}");
                    }
                    break;
                default:
                    Console.WriteLine("Unknown option, try again...");
                    break;
            }
            Console.WriteLine();
        } while (LOOP);

        Console.WriteLine();
        Console.WriteLine("Exiting Flight App...");
        Console.WriteLine("Thank You!");

    }// end of main

    public static void LoginToAccount(List<User> users)
    {
        Console.WriteLine();
        Console.WriteLine("[ Logging Into An Account ]");
        Console.Write("Please enter your Full Name: ");
        string loginName = Console.ReadLine();
        Console.Write("Please enter your Password: ");
        string loginPassword = Console.ReadLine();
        Console.WriteLine();
        
        User searchName = users.Find(searchName => searchName.Username.Equals(loginName, StringComparison.OrdinalIgnoreCase));
        if (loginPassword == searchName.Password)
        {
            Console.WriteLine("LOGIN SUCCESS!");
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
                Console.WriteLine("USER ACCOUNT NOT FOUND.");
            }
        }
        else
        {
            Console.WriteLine("LOGIN FAIL!");
        }
    }

    public static void RegisterAnAccount(List<User> users)
    {
        Console.WriteLine();
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
            Console.WriteLine();
            Console.WriteLine("You are now registered!");
            
            User newUser = new Passanger(registerName, registerEmail, registerPassword);
            users.Add(newUser);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Passwords do not match, please try again...");
        }
    }

}// end of program class
