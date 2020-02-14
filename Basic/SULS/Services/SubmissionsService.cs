namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using SULS.ViewModels.Submissions;
    using System;
    using System.Linq;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly SulsDbContext db;
        private readonly Random random;

        public SubmissionsService(SulsDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }

        public CreateFormViewModel CreateSubmissionForm(string id)
        {
            var viewModel = this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => new CreateFormViewModel
                {
                    Name = x.Name,
                    ProblemId = x.Id,
                }).FirstOrDefault();

            return viewModel;
        }

        public void CreateSubmissions(string userId, string problemId, string code)
        {
            var problem = this.db.Problems.FirstOrDefault(x => x.Id == problemId);
            var user = this.db.Users.FirstOrDefault(x => x.Id == userId);

            var submission = new Submission()
            {
                Code = code,
                AchievedResult = this.random.Next(0, problem.Points + 1),
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                ProblemId = problemId,
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void DeleteSubmission(string submissionId)
        {
            var submission = this.db.Submissions.Find(submissionId);

            this.db.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
