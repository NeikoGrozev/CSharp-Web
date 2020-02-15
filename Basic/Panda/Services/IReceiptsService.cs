namespace Panda.Services
{
    using ViewModels.Receipt;

    public interface IReceipsService
    {
        void CreateDeliverPackage(decimal weigth, string packageId, string recipientId);

        AllReceiptsViewModel GetAllReceipt();
    }
}
