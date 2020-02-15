namespace Panda.Contorllers
{
    using Services;
    using ViewModels.Package;

    using SIS.HTTP;
    using SIS.MvcFramework;

    public class PackagesController : Controller
    {
        private readonly IPackagesServer packagesServer;
        private readonly IUsersService usersService;

        public PackagesController(IPackagesServer packagesServer, IUsersService usersService)
        {
            this.packagesServer = packagesServer;
            this.usersService = usersService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var usernames = this.usersService.GetAllUsername();

            return this.View(usernames);
        }

        [HttpPost]
        public HttpResponse Create(CreatePackageViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if(input.Description.Length < 5 || input.Description.Length > 20)
            {
                return this.Redirect("Create");
            }

            this.packagesServer.CreatePackage(input.Description, input.Weight, input.ShippingAddress, input.RecipientName);

            return this.Redirect("/");
        }

        public HttpResponse Pending()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var packages = this.packagesServer.GetAllPendingPackage();
                       
            return this.View(packages);
        }

        public HttpResponse Deliver(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.packagesServer.PackageDelever(id);

            return this.Redirect("/Packages/Delivered");
        }

        public HttpResponse Delivered()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var packages = this.packagesServer.GetDeliveredPackage();

            return this.View(packages);
        }
    }
}
