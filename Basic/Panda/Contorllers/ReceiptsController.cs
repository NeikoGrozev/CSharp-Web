namespace Panda.Contorllers
{
    using Services;

    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ReceiptsController : Controller
    {
        private readonly IReceipsService receipsService;

        public ReceiptsController(IReceipsService receipsService)
        {
            this.receipsService = receipsService;
        }

        public HttpResponse Index()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.receipsService.GetAllReceipt();

            return this.View(viewModel);
        }
    }
}
