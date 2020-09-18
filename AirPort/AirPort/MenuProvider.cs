using System;

namespace AirPort
{
    class MenuProvider //Class to interact with the console
    {
        //Create a new flight and enter the values
        public static FlightItem NewFlight()
        {
            FlightItem newFlight = new FlightItem();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("From city name:");
            newFlight.FromCity = Console.ReadLine();
            Console.WriteLine("To city name:");
            newFlight.ToCity = Console.ReadLine();
            Console.WriteLine("Flight number:");
            newFlight.FlightNumber = Console.ReadLine();
            return newFlight;
        }

        //Show the flights in the panel. The index is the selected item. Redraw the screen each time the function is called
        public static void Show(FlightPanel panel, int index = 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Use keys 'Up','Down' - select a flight, 'Right','Left' - switch between arrivals and departures.");
            Console.WriteLine("'Enter' - edit selected flight, 'Int' - Add new flight.");
            Console.WriteLine();

            //Change 'Console.ForegroundColor' depending on the panel type
            Console.ForegroundColor = panel.IsArrival ? ConsoleColor.DarkCyan : ConsoleColor.DarkRed;

            //Change the flight panel caption depending on the panel type
            string panelCaption = panel.IsArrival ? "[Arrivals]" : "[Departures]";
            Console.WriteLine(panelCaption);
            Console.WriteLine();

            for (int i = 0; i < panel.Count(); i++)
            {
                //Change 'Console.ForegroundColor' for the selected item to green, else equal to DarkYellow
                Console.ForegroundColor = (index == i) ? ConsoleColor.Green : ConsoleColor.DarkYellow;

                //Get the current drawing item
                var currentFlight = panel.Get(i);
                if (currentFlight != null) // Item is found
                {
                    //Show the current flight
                    Console.WriteLine(
                        $"From: '{currentFlight.FromCity}' To: '{currentFlight.ToCity}' FlightNumber: '{currentFlight.FlightNumber}'");
                }
            }
        }
    }
}