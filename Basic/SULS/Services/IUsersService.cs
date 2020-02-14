namespace SULS.Services
{
    public interface IUsersService
    {
        void UserRegistration(string username, string email, string password);

        string GetUserId(string username, string password);
    }
}
