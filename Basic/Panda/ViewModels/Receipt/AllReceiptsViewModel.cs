namespace Panda.ViewModels.Receipt
{
    using System.Collections.Generic;

    public class AllReceiptsViewModel
    {
        public ICollection<ReceiptViewModel> Receipts { get; set; }
    }
}
