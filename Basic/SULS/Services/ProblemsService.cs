namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using SULS.ViewModels.Problems;
    using System.Linq;

    public class ProblemsService : IProblemsService
    {
        private readonly SulsDbContext db;

        public ProblemsService(SulsDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int point)
        {
            var problem = new Problem
            {
                Name = name,
                Points = point,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public DetailsViewModel GetDetailProblem(string id)
        {
            var viewModel = this.db.Problems.Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                  {
                      Name = x.Name,
                      Problems = x.Submissions.Select(s =>
                      new ProblemDetailsSubmissionViewModel
                      {
                          CreatedOn = s.CreatedOn,
                          AchievedResult = s.AchievedResult,
                          SubmissionId = s.Id,
                          MaxPoints = x.Points,
                          Username = s.User.Username,
                      })
                  }).FirstOrDefault();

            return viewModel;
        }
    }
}
