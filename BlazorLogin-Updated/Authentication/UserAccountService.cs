using System.Linq;

namespace BlazorServerAuthenticationAndAuthorization.Authentication
{
    public class UserAccountService
    {
        private readonly AuthDbContext _context;

        public UserAccountService(AuthDbContext context)
        {
            _context = context;
        }

        public UserAccount? GetByUserName(string userName)
        {
            return _context.UserAccounts.FirstOrDefault(u => u.UserName == userName);
        }

        public bool ValidateCredentials(string username, string password)
        {
            var user = GetByUserName(username);
            return user != null && BCrypt.Net.BCrypt.Verify(password, user.Password);
        }
        public List<UserAccount> GetAllUsers()
        {
            return _context.UserAccounts.ToList();
        }

        public void DeleteUser(int id)
        {
            var user = _context.UserAccounts.Find(id);
            if (user != null)
            {
                _context.UserAccounts.Remove(user);
                _context.SaveChanges();
            }
        }

        public void AddUser(string username, string password, string role)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var newUser = new UserAccount
            {
                UserName = username,
                Password = hashedPassword,
                Role = role
            };

            _context.UserAccounts.Add(newUser);
            _context.SaveChanges();
        }

        public bool UserExists(string username)
        {
            return _context.UserAccounts.Any(u => u.UserName == username);
        }
    }
}
