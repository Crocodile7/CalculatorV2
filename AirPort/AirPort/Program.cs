using System;
using System.Collections.Generic;

namespace AirPort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create 'Arrivals' && 'Departures' panels and fill with initial data

            var Arrivals = new FlightPanel(isArrival:true);
            Arrivals.Add(new FlightItem(){FlightNumber = "1",FromCity = "Kyiv", ToCity = "Riga"});
            Arrivals.Add(new FlightItem() { FlightNumber = "2", FromCity = "Tallin", ToCity = "Vilnus" });
            Arrivals.Add(new FlightItem() { FlightNumber = "3", FromCity = "New York", ToCity = "Boston" });

            var Departures = new FlightPanel(isArrival: false);
            Departures.Add(new FlightItem() { FlightNumber = "11", FromCity = "Kyiv", ToCity = "Riga" });
            Departures.Add(new FlightItem() { FlightNumber = "22", FromCity = "Tallin", ToCity = "Vilnus" });
            Departures.Add(new FlightItem() { FlightNumber = "33", FromCity = "New York", ToCity = "Boston" });
            Departures.Add(new FlightItem() { FlightNumber = "44", FromCity = "Lviv", ToCity = "Bangladesh" });

            FlightPanel visiblePanel = Arrivals; //The current visible panel

            ConsoleKeyInfo keyInfo; //The key, pressed  from the keyboard

            int cursorIndex = 0; //The index of the selected flight in the selected panel

            bool exitIsNeeded = false; //Flag to indicate if "Esc" is pressed

            while (!exitIsNeeded)
            {
                MenuProvider.Show(visiblePanel, cursorIndex);

                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    //Exit program when "Esc" is pressed
                    case ConsoleKey.Escape:
                    {
                        exitIsNeeded = true; //force "while()" to terminate
                        break;
                    }

                    //UP - decrease selected flight index. In case of negative - set to zero (first item)
                    case ConsoleKey.UpArrow:
                    {
                        cursorIndex = cursorIndex > 0 ? cursorIndex - 1 : 0;
                            break;
                    }

                    //DOWN - increase selected flight index. If it is greater than the number of flights - select the lase flight from the list
                    case ConsoleKey.DownArrow:
                    {
                        cursorIndex = cursorIndex < visiblePanel.Count() - 1 ? cursorIndex + 1 : 0;
                            break;
                    }

                    //LEFT - select the 'Arrivals' panel
                    case ConsoleKey.LeftArrow:
                    {
                        visiblePanel = Arrivals;
                            break;
                    }

                    //RIGHT - select the 'Departures' panel
                    case ConsoleKey.RightArrow:
                    {
                        visiblePanel = Departures;
                        break;
                    }

                    //INSERT - add new flight to the selected panel (in the end of the list)
                    case ConsoleKey.Insert:
                    {
                        visiblePanel.Add(newFlight: MenuProvider.NewFlight());
                            break;
                    }

                    //ENTER - create new item and replace the selected one (i.e. edit selected flight)
                    case ConsoleKey.Enter:
                    {
                        if (visiblePanel.IsIndexValid(cursorIndex))
                        {
                            visiblePanel.Update(cursorIndex, MenuProvider.NewFlight());
                        }
                        break;
                    }
                }
            }
        }
    }
}
