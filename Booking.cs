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
}
