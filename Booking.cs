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
    }

    // User based methods

    // Just calls user.GetBookedFlights and displays any flights in the bookedFlights list in user.cs
    public void DisplayMyFlights() 
    { 
        Console.WriteLine("Displaying flights....");
        Program.currentUser.GetBookedFlights();
    }

    public void SearchSpecificFlight() { }

    // Loops 
    public void BookFlight() 
    { 
        DisplayAllFlights();
        
        Console.Write("Please select type a flight number to book a seat: ");
        int flightNum = Convert.ToInt32(Console.ReadLine());

        Flight flight = flights.Find(flight => flight.FlightNumber.Equals(flightNum));
        if (flight != null) 
        {
            Console.Write("How many seats are you booking? ");
            int seatsBooked = Convert.ToInt32(Console.ReadLine());

            if (flight.UpdateSeats(seatsBooked) == "Seats booked")
            {
                Program.currentUser.AddFlightToList(flight);
                Console.WriteLine("Flight booked successfully");
            }
            else
            {
                Console.WriteLine("Flight could not be booked");
            }
        }
        else
        {
            Console.WriteLine("Flight not found");
            Console.WriteLine(flight);
        }

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

    public void RemoveAFlight() 
    {
        // 
    }

    public void EditFlightInfo() 
    { 
        // 
    }

    public void BookTestFlights() {
        DateTime test1Date = DateTime.Parse("10/11/26 09:00");
        DateTime test2Date = DateTime.Parse("14/12/26 17:00");
        DateTime test3Date = DateTime.Parse("01/02/27 08:45");
        DateTime test4Date = DateTime.Parse("02/09/27 20:15");
        
        Flight test1 = new Flight(test1Date, 001, "Sydney", "Wellington", 005, "On Time", 5);
        Flight test2 = new Flight(test2Date, 002, "Auckland", "Wellington", 006, "Delayed", 5);
        Flight test3 = new Flight(test3Date, 003, "Christchurch", "Wellington", 007, "On Time", 3);
        Flight test4 = new Flight(test4Date, 004, "Queenstown", "Wellington", 008, "On Time", 1);

        flights.Add(test1);
        flights.Add(test2);
        flights.Add(test3);
        flights.Add(test4);
    }
}
