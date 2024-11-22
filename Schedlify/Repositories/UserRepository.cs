using Schedlify.Data;
using Schedlify.Models;

namespace Schedlify.Repositories;

public class UserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get user by ID
    public User? GetById(Guid userId)
    {
        return _context.Users
            .FirstOrDefault(u => u.Id == userId);  // Find the user by ID
    }

    // Get user by Login
    public User? GetByLogin(string login)
    {
        return _context.Users
            .FirstOrDefault(u => u.Login == login);  // Find the user by login
    }

    // Add a new user
    public User Add(string login, string passwordHash)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),  // Generate a new GUID for the user
            Login = login,
            PasswordHash = passwordHash
        };

        _context.Users.Add(user);  // Add the user to the DbSet
        _context.SaveChanges();    // Save changes to the database

        return user;  // Return the added user
    }
}
