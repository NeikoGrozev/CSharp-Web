namespace Panda.Services
{
    using Data;
    using Models;
    using Models.Enums;
    using ViewModels.Package;

    using System.Linq;

    public class PackagesServer : IPackagesServer
    {
        private readonly PandaDbContext db;
        private readonly IReceipsService receipsService;

        public PackagesServer(PandaDbContext db, IReceipsService receipsService)
        {
            this.db = db;
            this.receipsService = receipsService;
        }

        public void CreatePackage(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var recipien = this.db.Users.FirstOrDefault(x => x.Username == recipientName);

            var package = new Package()
            {
                Description = description,
                Weight = weight,
                ShippingAddress = shippingAddress,
                RecipientId = recipien.Id,
            };

            this.db.Packages.Add(package);
            this.db.SaveChanges();
        }

        public AllPackageViewModel GetAllPendingPackage()
        {
            var packages = new AllPackageViewModel()
            {
                Packages = this.db.Packages.Where(x => x.Status == StatusEnums.Pending)
                 .Select(x => new PackageViewModel()
                 {
                     Id = x.Id,
                     Description = x.Description,
                     ShippingAddress = x.ShippingAddress,
                     Weight = x.Weight,
                     RecipientName = x.Recipient.Username,
                 }).ToList()
            };

            return packages;
        }

        public void PackageDelever(string id)
        {
            var package = this.db.Packages.FirstOrDefault(x => x.Id == id);

            if(package == null)
            {
                return;
            }

            package.Status = StatusEnums.Delivered;
            this.db.SaveChanges();

            this.receipsService.CreateDeliverPackage(package.Weight, package.Id, package.RecipientId);
        }

        public AllDeliveredPackagesViewModel GetDeliveredPackage()
        {                
            var allDeliveredPackage = new AllDeliveredPackagesViewModel()
            {
                Packages = this.db.Packages.Where(x => x.Status == StatusEnums.Delivered)
                .Select(x => new DeliveredPackageViewModel()
                {
                    Description = x.Description,
                    Weight = x.Weight,
                    ShippingAddress = x.ShippingAddress,
                    RecipientName = x.Recipient.Username
                }).ToList()
            };

            return allDeliveredPackage;
        }
    }
}
