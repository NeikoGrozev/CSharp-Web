namespace SULS.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;
    using SULS.Services;
    using SULS.ViewModels.Users;
    using System;
    using System.Net.Mail;

    public class UsersController : Controller
    {
        private readonly UsersService usersService;

        public UsersController(UsersService usersService)
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
        public HttpResponse Login(LoginInputViewModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var userId = usersService.GetUserId(input.Username, input.Password);

            if(userId == null)
            {
                return this.View();
            }

            this.SignIn(userId);

            return this.Redirect("/");
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
        public HttpResponse Register(RegistrationViewInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            if (input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be betwen 5 and 20 characters!");
            }

            if (!IsValid(input.Email))
            {
                return this.Error("Invalid email!");
            }

            if(input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be betwen 6 and 20 characters!");
            }

            if(input.Password != input.ConfirmPassword)
            {
                return this.Error("Passwords should be the same!");
            }

            usersService.UserRegistration(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

        private bool IsValid(string emailaddress)
        {
            try
            {
                new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
