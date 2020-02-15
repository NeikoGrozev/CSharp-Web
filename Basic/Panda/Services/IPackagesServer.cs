namespace Panda.Services
{
    using ViewModels.Package;

    public interface IPackagesServer
    {
        void CreatePackage(string description, decimal weight, string shippingAddress, string recipientName);

        AllPackageViewModel GetAllPendingPackage();

        void PackageDelever(string id);

        AllDeliveredPackagesViewModel GetDeliveredPackage();
    }
}
