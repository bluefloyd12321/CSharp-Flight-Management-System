namespace FlightManagementSystem;

public class Flight
{
	// These are the fields defined. These are private
	private DateTime flightDate;
	private int flightNumber;
	private string flightDestination;
	private string flightOrigin;
	private int gateNumber;
	private string flightStatus;
	private int seatsAvailable;

	// These are the current properties. For now they are auto-implementing. Subject to change if required.
	public DateTime FlightDate { get; set; }
	public int FlightNumber { get; set; }
	public string FlightDestination { get; set; }
	public string FlightOrigin { get; set; }
	public int GateNumber { get; set; }
	public string FlightStatus { get; set; }
	public int SeatsAvailable { get; set; }

	// Constructor
	public Flight(DateTime date, int flightNum, string destination, string origin, int gate, string status, int seats) 
	{
		FlightDate = date;
		FlightNumber = flightNum;
		FlightDestination = destination;
		FlightOrigin = origin;
		GateNumber = gate;
		FlightStatus = status;
		SeatsAvailable = seats;
	}

	// Method to update the flight status
	public void UpdateStatus(string status)
	{
		FlightStatus = status;
	}

	// Update the seats available for this flight.
	public string UpdateSeats(int seatsBooked)
	{
		int tooMany = SeatsAvailable - seatsBooked;

		// Checks if the seats booked would cause seats available to fall to 0 or below
		if (tooMany <= 0)
		{
			// If so, tell the user they can't book that many
			return "Sorry, there are no more seats left.";
		}

		else 
		{
			// If not, update the amount of seats left and say the seats were booked
			SeatsAvailable -= seatsBooked;
			return "The seats have been booked";
		}
	}
}
