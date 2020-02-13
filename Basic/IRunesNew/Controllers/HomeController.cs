﻿namespace IRunesNew.Controllers
{
    using Services;
    using ViewModels.Home;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IUsersService usersService;

        public HomeController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = new IndexViewModel();
                viewModel.Username = this.usersService.GetUsername(this.User);

                return this.View(viewModel, "Home");
            }

            return this.View();
        }

        [HttpGet("/Home/Index")]
        public HttpResponse HomeIndex()
        {
            return this.Redirect("/");
        }
    }
}
