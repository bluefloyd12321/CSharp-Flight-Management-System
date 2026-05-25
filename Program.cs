using System.Threading.Channels;
using System.Transactions;

namespace FlightManagementSystem;

class Program
{
    static void Main(string[] args)
    {

        // created main menu loop and methods for logging in and regestering an account

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
                    break; 
                case 1:
                    LoginToAccount();
                    break;
                case 2:
                    RegisterAnAccount();
                    break;
                default:
                    Console.WriteLine("Unknown option, try again...");
                    break;
            }
        } while (LOOP);

        Console.WriteLine("Exiting Flight App...");
        Console.WriteLine("Thank You!");

    }// end of main

    public static void LoginToAccount()
    {
        Console.WriteLine();
        Console.WriteLine("[ Logging Into An Account ]");
        Console.Write("Please enter your Full Name: ");
        string loginName = Console.ReadLine();
        Console.Write("Please enter your Password: ");
        string loginPassword = Console.ReadLine();

        return;
    }

    public static void RegisterAnAccount()
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

        return;
    }

}// end of program class
