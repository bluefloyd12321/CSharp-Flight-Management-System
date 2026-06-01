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
        DateTime testDate = new DateTime(2026, 6, 5);
        Flight testFlight = new Flight(testDate, 420, "Wellington", "Auckland", 12, "On Time", 10);
        flights.Add(testFlight);
    }

    public void RemoveAFlight() { }

    public void EditFlightInfo() { }
}
