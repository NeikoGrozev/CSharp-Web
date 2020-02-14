namespace Andreys.Controllers
{
    using Services;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Users;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginFormViewModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = this.usersService.GetUserId(input.Username, input.Password);

            if (userId != null)
            {
                this.SignIn(userId);

                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }


        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterFormViewModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Username.Length < 4 || input.Username.Length > 10)
            {
               // return this.Error("Username should be between 4 and 20 characters!");
                return this.Redirect("Register");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                //return this.Error("Password should be between 6 and 20 characters!");
                return this.Redirect("Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                //return this.Error("Password should match.");
                return this.Redirect("Register");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                //return this.Error("Email cannot be empty!");
                return this.Redirect("Register");
            }

            if (this.usersService.EmailExists(input.Email))
            {
                //return this.Error("Email already in use.");
                return this.Redirect("Register");
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                //return this.Error("Username already in use.");
                return this.Redirect("Register");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
