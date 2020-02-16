namespace SharedTrip.Services
{
    using Models;
    using ViewModels.Trip;

    using System.Linq;

    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateTrip(AddTripFormViewModel input)
        {
            var trip = new Trip()
            {
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                DepartureTime = input.DepartureTime,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
                Description = input.Description,
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public AllTripsViewModel GetAllTrips()
        {
            var viewModel = new AllTripsViewModel()
            {
                Trips = this.db.Trips
                .Select(x => new TripViewModel()
                {
                    TripId = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime,
                    Seats = x.Seats,
                }).ToList()
            };

            return viewModel;
        }

        public DetailsViewModel GetDetailTrip(string tripId)
        {            
            var viewModel = this.db.Trips.Where(x => x.Id == tripId)
               .Select(x => new DetailsViewModel()
               {
                   Id = x.Id,
                   StartPoint = x.StartPoint,
                   EndPoint = x.EndPoint,
                   DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                   Seats = x.Seats,
                   ImagePath = x.ImagePath,
                   Description = x.Description,
               }).FirstOrDefault();

            return viewModel;
        }

        public void JoinUserAndTrip(string tripId, string userId)
        {
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);

            bool isTrue = this.db.UserTrips.Any(x => x.TripId == tripId && x.UserId == userId);

            if(isTrue)
            {
                return;
            }

            if(trip.Seats > 1)
            {
                trip.Seats -= 1;
                
                var userTrip = new UserTrip()
                {
                    TripId = tripId,
                    UserId = userId,
                };

                this.db.UserTrips.Add(userTrip);
                this.db.SaveChanges();
            }
        }
    }
}
