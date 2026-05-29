namespace FlightManagementSystem;

public class Booking
{
    // Fields
    private List<Flight> flights;

    // Properties

    // Methods

    // Does what it says on the tin
    public void DisplayAllFlights()
    {
        // Loops through each flight in the list and displays the details
        foreach (Flight plane in flights)
        {
            plane.DisplayFlightDetails();
        }
    }

    // User based methods

    public void DisplayMyFlights() { }

    public void SearchSpecificFlight() { }

    public void BookFlight() { }

    public void UnBookFlight() { }

    // Admin based methods

    public void AddNewFlight()
    {
        DateTime testDate = new DateTime(2001, 9, 11);
        Flight testFlight = new Flight(testDate, 420, "Your mums house", "My house", 69, "In Flight", 1);
        flights.Add(testFlight);
    }

    public void RemoveAFlight() { }

    public void EditFlightInfo() { }
}
