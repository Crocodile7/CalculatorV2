using System.Collections.Generic;

namespace AirPort
{
    class FlightPanel
    {
        private List<FlightItem> _flights;

        public bool IsArrival { get; } //Property to indicate if the panel is the 'Arrivals'

        public bool IsIndexValid(int index)
        {
            return !((index >= Count()) || (index < 0)); //out of bounds validation
        }

        public FlightPanel(bool isArrival)
        {
            _flights = new List<FlightItem>();  //Creates an empty list of the flights
            IsArrival = isArrival;              //The only place we can fill it is the constructor of the panel
        }

        //Add new flight to the end of the list
        public void Add(FlightItem newFlight)
        {
            _flights.Add(newFlight);
        }

        //Get the flight from the list ('index' is the position)
        public FlightItem Get(int index)
        {
            //return null in case index is out of bounds
            return IsIndexValid(index) ? _flights[index] : null;
        }

        //Edit the flight in the list ('index' is the position)
        public void Update(int index, FlightItem updatedFlight)
        {
            if (IsIndexValid(index))
            {
                _flights[index] = updatedFlight;
            }
        }

        //Returns the number if items in the list
        public int Count()
        {
            return _flights.Count;
        }
    }
}