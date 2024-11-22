using Schedlify.Data; 
using Schedlify.Models; 
using Schedlify.Repositories;

namespace Schedlify.Tests;

public class RepoTests
{
    public static void TestUserRepo()
    {
        ApplicationDbContext context = DbContextFactory.CreateDbContext();
        UserRepository userRepository = new UserRepository(context);
        userRepository.Add("admin@admin.com", "superhash");
        User? user = userRepository.GetByLogin("admin@admin.com");
        Console.WriteLine(user?.Login);
    }

    public static void Run()
    {
        TestUserRepo();
    }
}