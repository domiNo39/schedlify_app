using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schedlify.Data;
using Schedlify.Repositories;
using Schedlify.Models;

namespace Schedlify.Controllers
{
    public class UsersController
    {
        private readonly UserRepository userRepository;
        public UsersController()
        {
            ApplicationDbContext _context = ApplicationDbContextFactory.CreateDbContext();
            userRepository = new UserRepository(_context);
        }
        public User? Login(string login, string password)
        {
            var user = userRepository.GetByLogin(login);
            if (user == null)
            {
                return null;
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        public User? Register(string login, string password)
        {
            var existingUser = userRepository.GetByLogin(login);
            if (existingUser != null)
            {
                return null;
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = userRepository.Add(login, passwordHash);

            return newUser; 
        }



    }
}
