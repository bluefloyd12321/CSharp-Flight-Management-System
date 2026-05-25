using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Transactions;

namespace FlightManagementSystem;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "*** Flight Reservation App ***";

        List<User> users = new List<User>();
        User vee = new User("Vee McCabe", "Vee@gmail.com", "0224623917", "ADMIN");
        users.Add(vee);




        int mainMenuOption;
        bool LOOP = true;
        do
        {
            Console.WriteLine();
            Console.WriteLine("******************************");
            Console.WriteLine("*** Flight Reservation App ***");
            Console.WriteLine("******************************");
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
                case 3:
                    Console.WriteLine();
                    Console.WriteLine("DEBUG MODE");
                    foreach (User x in users)
                    {
                        Console.WriteLine($"user");
                    }
                    break;
                default:
                    Console.WriteLine("Unknown option, try again...");
                    break;
            }
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

        return;
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
            
            User newUser = new User(registerName, registerEmail, registerPassword, "PASSANGER");
            users.Add(newUser);
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Passwords do not match, please try again...");
        }

        return;
    }

}// end of program class
