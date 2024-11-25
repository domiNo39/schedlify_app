using NLog;
using Schedlify.Data;
using Schedlify.Repositories;
using Schedlify.Models;


namespace Schedlify.Controllers
{
    public class UsersController
    {
        private readonly UserRepository userRepository;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UsersController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            userRepository = new UserRepository(_context);
        }

        public UsersController(ApplicationDbContext context)
        {
            ApplicationDbContext _context = context;
            userRepository = new UserRepository(_context);
        }

        public User? Login(string login, string password)
        {
            logger.Info($"Attempting login for user: {login}");
            var user = userRepository.GetByLogin(login);

            if (user == null)
            {
                logger.Warn($"Login failed for user: {login} - User not found.");
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                logger.Warn($"Login failed for user: {login} - Incorrect password.");
                return null;
            }

            logger.Info($"Login successful for user: {login}");
            return user;
        }

        public User? Register(string login, string password)
        {
            logger.Info($"Attempting registration for user: {login}");
            var existingUser = userRepository.GetByLogin(login);

            if (existingUser != null)
            {
                logger.Warn($"Registration failed for user: {login} - User already exists.");
                return null;
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var newUser = userRepository.Add(login, passwordHash);

            logger.Info($"Registration successful for user: {login}");
            return newUser;
        }
    }
}
