namespace SULS.ViewModels.Users
{
    using System.Collections.Generic;

    public class LoggedInViewModel
    {
        public ICollection<IndexProblemLoginViewModel> Problems { get; set; }
    }
}
