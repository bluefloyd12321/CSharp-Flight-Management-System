using System.ComponentModel;

namespace FlightManagementSystem;

public class Booking
{
    // Fields
    private List<Flight> flights = new List<Flight>();

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
        Program.currentUser.GetBookedFlights();
    }

    // Method for searching for a flight
    public void SearchSpecificFlight()
    {
        List<Flight> flightSearchResults = new List<Flight>();
        bool LOOP = true;
        do
        {
            int choice = 99;
            // Asks the user if they want to search by origin or destination
            Console.WriteLine("1) Search by Flight Destination");
            Console.WriteLine("2) Search by Flight Origin");
            Console.WriteLine("0) Back");

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, please enter a number.");
            }

            switch (choice)
            {
                // Asks the user to input the destination. Then searches for that destination and displays the results
                case 1:
                    Console.Write("Please enter a destination to search for: ");
                    string destination = Console.ReadLine();
                    foreach (Flight flight in flights)
                    {
                        if (flight.FlightDestination == destination)
                        {
                            flightSearchResults.Add(flight);
                        }
                    }
                    Console.WriteLine($"We found {flightSearchResults.Count()} flights going to {destination}:");
                    foreach (Flight flight in flightSearchResults)
                    {
                        flight.DisplayFlightDetails();
                    }
                    Console.Write("Please press any key to continue...");
                    Console.ReadLine();
                    break;
                // Asks the user to input the origin. Searches then displays those results
                case 2:
                    Console.Write("Please enter an origin to search for: ");
                    string origin = Console.ReadLine();
                    foreach (Flight flight in flights)
                    {
                        if (flight.FlightOrigin == origin)
                        {
                            flightSearchResults.Add(flight);
                        }
                    }
                    Console.WriteLine($"We found {flightSearchResults.Count()} flights from to {origin}:");
                    foreach (Flight flight in flightSearchResults)
                    {
                        flight.DisplayFlightDetails();
                    }
                    Console.Write("Please press any key to continue...");
                    Console.ReadLine();
                    break;
                // Simply goes back
                case 0:
                    Console.WriteLine("Okay, going back...");
                    LOOP = false;
                    break;
                default:
                    break;
            }
            Console.WriteLine(flightSearchResults.Count);
            for (int i = flightSearchResults.Count - 1; i >= 0; i--)
            {
                flightSearchResults.RemoveAt(i);
            }
            Console.Clear();
        } while (LOOP);
    }

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
            Console.Clear();
            if (flight.UpdateSeats(seatsBooked) == "Seats booked")
            {
                Program.currentUser.AddFlightToList(flight);
                Console.WriteLine("Flight booked successfully...");
            }
            else
            {
                Console.WriteLine("Flight could not be booked...");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Flight not found...");
            Console.Write(flight);
        }
        Console.WriteLine();

    }

    // Method for unbooking the flights
    public void UnBookFlight()
    {
        int flightNum = 0;
        // Displays flights to the user
        DisplayMyFlights();
        Console.Write("Please enter the flight number to unbook: ");
        try
        {
            flightNum = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Sorry, please enter a number.");
        }

        // Checks for flights in the booked flights list. Then confirms if the user wants to remove flight and remvoves the flight
        Flight flight = Program.currentUser.bookedFlights.Find(flight => flight.FlightNumber.Equals(flightNum));
        if (flight != null)
        {
            Console.Write("How many seats did you book? ");
            int seatsBooked = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Are you sure you wish to unbook (yes/no)? ");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() == "yes")
            {
                flight.UnbookSeats(seatsBooked);
                Program.currentUser.bookedFlights.Remove(flight);
                Console.WriteLine("Flight has been unbooked.");
            }
            else
            {
                Console.WriteLine("Flight has not been unbooked.");
            }
        }
    }

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
        Console.WriteLine();

        // Adds flight to the list
        Flight newFlight = new Flight(flightDate, flightNum, flightDest, flightOrigin, gateNum, flightStat, seatsAvailable);
        flights.Add(newFlight);
    }

    // Method for removing a flight
    public void RemoveAFlight()
    {
        // Displays options to the user
        DisplayAllFlights();
        Console.Write("Please enter then number of the flight you'd like to remove: ");
        int flightNum = Convert.ToInt32(Console.ReadLine());

        // Searches for the flight, asks the user if they want to remove then removes flight.
        Flight flight = flights.Find(flight => flight.FlightNumber.Equals(flightNum));
        if (flight != null)
        {
            Console.Write($"Are you sure you want to remove flight {flight.FlightNumber} (yes/no)? ");
            string confirm = Console.ReadLine();
            Console.Clear();
            if (confirm.ToLower() == "yes")
            {
                flights.Remove(flight);
                Console.WriteLine("Flight removed...");
            }
            else
            {
                Console.WriteLine("Okay, going back...");
            }
        }
        else
        {
            Console.WriteLine("Flight not found...");
            Console.Write(flight);
        }
        Console.WriteLine();
    }

    // Edits the information for a given flight. 
    public void EditFlightInfo()
    {
        // Shows the flights to the user
        DisplayAllFlights();
        Console.Write("Please enter the flight number for the flight you want to edit: ");
        int flightNum = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        // Searches for the flight
        Flight flight = flights.Find(flight => flight.FlightNumber.Equals(flightNum));
        if (flight != null)
        {
            Console.WriteLine($"Editing flight number [{flight.FlightNumber}]...");
            Console.WriteLine();

            int choice = 9999;
            bool LOOP = true;
            do
            {
                
                flight.DisplayFlightDetails();
                // Displays options to the user then asks for their input
                Console.WriteLine("1) Flight Date");
                Console.WriteLine("2) Flight Destination");
                Console.WriteLine("3) Flight Origin");
                Console.WriteLine("4) Gate Number");
                Console.WriteLine("5) Flight Status");
                Console.WriteLine("6) Seats Available");
                Console.WriteLine("7) Go Back");
                Console.WriteLine();
                Console.Write("Which section do you want to edit: ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Sorry, please enter a number.");
                }

                // Based on their choice, give the option to edit that piece of information.
                switch (choice)
                {
                    case 1:
                        DateTime flightDate = default;
                        Console.Write("Please enter the new date: ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime potentialDate))
                        {
                            flightDate = potentialDate;
                        }
                        flight.FlightDate = flightDate;
                        Console.Clear();
                        Console.WriteLine("Date has been updated...");
                        break;
                    case 2:
                        Console.Write("Please enter the new destination: ");
                        string destination = Console.ReadLine();
                        flight.FlightDestination = destination;
                        Console.Clear();
                        Console.WriteLine("Destination has been updated...");
                        break;
                    case 3:
                        Console.Write("Please enter the new origin: ");
                        string origin = Console.ReadLine();
                        flight.FlightOrigin = origin;
                        Console.Clear();
                        Console.WriteLine("Origin has been updated...");
                        break;
                    case 4:
                        Console.Write("Please enter the new gate number: ");
                        int gateNum = Convert.ToInt32(Console.ReadLine());
                        flight.GateNumber = gateNum;
                        Console.Clear();
                        Console.WriteLine("Gate number has been updated...");
                        break;
                    case 5:
                        Console.Write("Please enter the new status: ");
                        string status = Console.ReadLine();
                        flight.FlightStatus = status;
                        Console.Clear();
                        Console.WriteLine("Status has been updated...");
                        break;
                    case 6:
                        Console.Write("Please enter the new amount of seats available: ");
                        int seats = Convert.ToInt32(Console.ReadLine());
                        flight.SeatsAvailable = seats;
                        Console.Clear();
                        Console.WriteLine("Seats available has been updated...");
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("Okay, going back...");
                        LOOP = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Sorry, that's not a valid option. Please try again...");
                        break;
                }
                Console.WriteLine();
            } while (LOOP);

        }
        else
        {
            Console.WriteLine("Flight Not Found");
        }
    }

    // Just books some test flights
    public void BookTestFlights()
    {
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
