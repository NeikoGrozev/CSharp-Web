namespace IRunesNew.Controllers
{
    using IRunesNew.Services;
    using IRunesNew.ViewModels.Tracks;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = new CreateFormViewModel
            {
                AlbumId = albumId
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(CreateViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Track name should be between 4 and 20 characters.");
            }

            if (!input.Link.StartsWith("http"))
            {
                return this.Error("Invalid link.");
            }

            if (input.Price < 0)
            {
                return this.Error("Price should be a positive number.");
            }

            this.tracksService.CreateTrack(input.Name, input.Link, input.Price, input.AlbumId);

            return this.Redirect("/Albums/Details?id=" + input.AlbumId);
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.tracksService.GetDetails(albumId, trackId);

            return this.View(viewModel);
        }
    }
}

