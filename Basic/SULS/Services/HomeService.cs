namespace SULS.Services
{
    using SULS.Data;
    using SULS.ViewModels.Users;
    using System.Collections.Generic;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private readonly SulsDbContext db;

        public HomeService(SulsDbContext db)
        {
            this.db = db;
        }

        public LoggedInViewModel GetLoggetInViewModel()
        {
            var LoggedInViewModel = new LoggedInViewModel
            {
                Problems = GetAllProblems()
            };

            return LoggedInViewModel;
        }

        public List<IndexProblemLoginViewModel> GetAllProblems()
        {
            var problems = this.db.Problems.Select(x => new IndexProblemLoginViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count()

            }).ToList();

            return problems;
        }
    }
}
