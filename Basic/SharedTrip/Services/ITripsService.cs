namespace SharedTrip.Services
{
    using ViewModels.Trip;

    public interface ITripsService
    {
        void CreateTrip(AddTripFormViewModel input);

        AllTripsViewModel GetAllTrips();

        DetailsViewModel GetDetailTrip(string tripId);

        void JoinUserAndTrip(string tripId, string userId);
    }
}
