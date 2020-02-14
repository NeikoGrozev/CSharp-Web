namespace SULS.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.Services;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = homeService.GetLoggetInViewModel();

                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse HomeIndex()
        {
            return this.Index();
        }        
    }
}
