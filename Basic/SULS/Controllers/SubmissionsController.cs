namespace SULS.Controllers
{
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(ISubmissionsService submissionsService)
        {
            this.submissionsService = submissionsService;
        }


        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var viewModel = this.submissionsService.CreateSubmissionForm(id);

            if (viewModel == null)
            {
                return this.Error("Problem not Found!");
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (code == null || code.Length < 30)
            {
                return this.Error("Please, your code should be input minimum 30 characters!");
            }

            if (code.Length > 800)
            {
                return this.Error("Please, your code should be input maximum 800 characters!");
            }

            this.submissionsService.CreateSubmissions(this.User, problemId, code);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string Id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.submissionsService.DeleteSubmission(Id);

            return this.Redirect("/");
        }
    }
}
