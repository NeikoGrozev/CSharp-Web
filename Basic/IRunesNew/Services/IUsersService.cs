namespace IRunesNew.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string password, string email);

        string GetUserId(string username, string password);

        bool EmailExists(string email);

        bool UsernameExists(string username);

        string GetUsername(string user);
    }
}
