namespace Panda.Contorllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeContorller : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.View();
            }

            return this.View("IndexLoggedIn");
        }

        [HttpGet("/Home/Index")]
        public HttpResponse HomeIndex()
        {
            return this.Redirect("/");
        }
    }
}
