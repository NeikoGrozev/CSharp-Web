namespace SharedTrip.ViewModels.Trip
{
    using System.Collections.Generic;

    public class AllTripsViewModel
    {
        public IEnumerable<TripViewModel> Trips { get; set; }
    }
}
