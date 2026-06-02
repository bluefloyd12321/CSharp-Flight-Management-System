using System.ComponentModel;

namespace FlightManagementSystem;

public class Booking
{
    // Fields
    private List<Flight> flights = new List<Flight>();

    // Properties

    // Methods

    // Does what it says on the tin
    public void DisplayAllFlights()
    {
        // Loops through each flight in the list and displays the details
        foreach (Flight flight in flights)
        {
            flight.DisplayFlightDetails();
        }
        if (Program.currentUser is Admin)
        {
            Console.WriteLine("Is Admin");
        }
        else {
            Console.WriteLine("Is passenger");
        }
    }

    // User based methods

    public void DisplayMyFlights() 
    { 
        System.Console.WriteLine("Displaying flights....");
        Program.currentUser.GetBookedFlights();
    }

    public void SearchSpecificFlight() { }

    public void BookFlight() 
    { 
        int flightNum = 420;
        Flight searchFlight = flights.Find(searchFlight => searchFlight.FlightNumber.Equals(flightNum));
        Program.currentUser.AddFlightToList(searchFlight);
        Console.WriteLine("success");
    }

    public void UnBookFlight() { }

    // Admin based methods

    public void AddNewFlight()
    {
        // Prompts the user for all the flight details
        DateTime flightDate = default;
        Console.Write("Please enter the flight Date & Time (dd/mm/yyyy hh:mm): ");
        if (DateTime.TryParse(Console.ReadLine(), out DateTime potentialDate))
        {
            flightDate = potentialDate;
        }

        Console.Write("Please enter the flight number: ");
        int flightNum = Convert.ToInt32(Console.ReadLine());

        Console.Write("Please enter the flight destination: ");
        string flightDest = Console.ReadLine();

        Console.Write("Please enter the flight origin: ");
        string flightOrigin = Console.ReadLine();

        Console.Write("Please enter the flight gate Number: ");
        int gateNum = Convert.ToInt32(Console.ReadLine());

        Console.Write("Please enter the flight status: ");
        string flightStat = Console.ReadLine();

        Console.Write("Please enter the flight seats available: ");
        int seatsAvailable = Convert.ToInt32(Console.ReadLine());

        // Adds flight to the list
        Flight newFlight = new Flight(flightDate, flightNum, flightDest, flightOrigin, gateNum, flightStat, seatsAvailable);
        flights.Add(newFlight);
    }

    public void RemoveAFlight() { }

    public void EditFlightInfo() { }
}
