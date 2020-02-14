namespace SULS.Services
{
    using SULS.ViewModels.Users;
    using System.Collections.Generic;

    public interface IHomeService
    {
        LoggedInViewModel GetLoggetInViewModel();

        List<IndexProblemLoginViewModel> GetAllProblems();
    }
}
