namespace SharedTrip.Controllers
{
    using Services;
    using ViewModels.Trip;

    using SIS.HTTP;
    using SIS.MvcFramework;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if(!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(AddTripFormViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if(string.IsNullOrWhiteSpace(input.StartPoint))
            {
                return this.View("Add");
            }

            if (string.IsNullOrWhiteSpace(input.EndPoint))
            {
                return this.View("Add");
            }

            if(input.DepartureTime == null)
            {
                return this.View("Add");
            }

            if(input.Seats < 2 || input.Seats > 6)
            {
                return this.View("Add");
            }

            if(input.Description.Length < 0 || input.Description.Length > 80)
            {
                return this.View("Add");
            }

            this.tripsService.CreateTrip(input);

            return this.Redirect("All"); 
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.tripsService.GetAllTrips();

            return this.View(viewModel);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.tripsService.GetDetailTrip(tripId);

            return this.View(viewModel);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.User;

            this.tripsService.JoinUserAndTrip(tripId, userId);

            return this.Redirect("All");
        }
    }
}
