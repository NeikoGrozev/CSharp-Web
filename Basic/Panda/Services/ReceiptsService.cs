namespace Panda.Services
{
    using Data;
    using Models;
    using ViewModels.Receipt;

    using System;
    using System.Linq;

    public class ReceiptsService : IReceipsService
    {
        private readonly PandaDbContext db;

        public ReceiptsService(PandaDbContext db)
        {
            this.db = db;
        }

        public void CreateDeliverPackage(decimal weigth, string packageId, string recipientId)
        {
            var package = new Receipt()
            {
                PackageId = packageId,
                Fee = weigth * 2.67M,
                IssuedOn = DateTime.UtcNow,
                RecipientId = recipientId,
            };

            this.db.Receipts.Add(package);
            this.db.SaveChanges();
        }

        public AllReceiptsViewModel GetAllReceipt()
        {
            var receipts = new AllReceiptsViewModel()
            {
                Receipts = this.db.Receipts
                .Select(x => new ReceiptViewModel()
                {
                    Id = x.Id,
                    Fee = x.Fee,
                    IssuedOn = x.IssuedOn,
                    RecipientName = x.Recipient.Username,
                }).ToList()
            };

            return receipts;
        }
    }
}
