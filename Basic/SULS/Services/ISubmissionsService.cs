namespace SULS.Services
{
    using SULS.ViewModels.Submissions;

    public interface ISubmissionsService
    {
        CreateFormViewModel CreateSubmissionForm(string id);

        void CreateSubmissions(string username, string problemId, string code);

        void DeleteSubmission(string submissionId);
    }
}
