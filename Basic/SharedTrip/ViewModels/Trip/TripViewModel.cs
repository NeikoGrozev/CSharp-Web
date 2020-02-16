namespace SharedTrip.ViewModels.Trip
{
    using System;

    public class TripViewModel
    {
        public string TripId { get; set; }

        public string StartPoint { get; set; }

        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public int Seats { get; set; }
    }
}
