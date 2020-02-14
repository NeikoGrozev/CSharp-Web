namespace SULS.Services
{
    using SULS.Data;
    using SULS.Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly SulsDbContext db;

        public UsersService(SulsDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = Hash(password);
            var userId = db.Users
                .Where(x => x.Username == username && x.Password == hashPassword)
                .Select(x => x.Id)
                .FirstOrDefault();

            if(userId == null)
            {
                return null;
            }

            return userId;
        }

        public void UserRegistration(string username, string email, string password)
        {
            var hashPassword = Hash(password);
            var user = new User
            {
                Username = username,
                Email = email,
                Password = hashPassword,
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        private string Hash(string input)
        {
            if (input == null)
            {
                return null;
            }

            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
