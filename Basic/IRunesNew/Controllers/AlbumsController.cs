namespace IRunesNew.Controllers
{
    using Services;
    using ViewModels.Albums;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = new AllAlbumsViewModel
            {
                Albums = this.albumsService.GetAllAlbums()
            };

            if (viewModel == null)
            {
                return this.Error("There are currently no albums.");
            }

            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateAlbumViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Error("Name should be with length between 4 and 20");
            }

            if (string.IsNullOrWhiteSpace(input.Cover))
            {
                return this.Error("Cover is required.");
            }

            this.albumsService.CreateAlbum(input.Name, input.Cover);

            return this.Redirect("All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.albumsService.GetDetails(id);

            return this.View(viewModel);
        }
    }
}
