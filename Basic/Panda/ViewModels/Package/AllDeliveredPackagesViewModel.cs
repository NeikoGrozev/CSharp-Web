namespace Panda.ViewModels.Package
{
    using System.Collections.Generic;

    public class AllDeliveredPackagesViewModel
    {
        public IEnumerable<DeliveredPackageViewModel> Packages { get; set; }
    }
}
