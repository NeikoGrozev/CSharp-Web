namespace IRunesNew.Services
{
    using Data;
    using Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly IRunesDbContex db;

        public UsersService(IRunesDbContex db)
        {
            this.db = db;
        }

        public void CreateUser(string username, string password, string email)
        {
            var hashPassword = Hash(password);

            var user = new User
            {
                Username = username,
                Password = hashPassword,
                Email = email,
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
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

        public bool EmailExists(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        public string GetUserId(string username, string password)
        {
            var hashPassword = Hash(password);

            var user = this.db.Users.FirstOrDefault(x => x.Username == username 
                        && x.Password == hashPassword);

            if(user == null)
            {
                return null;
            }

            return user.Id;
        }

        public string GetUsername(string id)
        {
            var username = this.db.Users.FirstOrDefault(x => x.Id == id);

            return username.Username;
        }
    }
}
