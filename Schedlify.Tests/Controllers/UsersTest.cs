namespace Schedlify.Tests.Controllers;

using Schedlify.Controllers;
using Schedlify.Models;
using Schedlify.Data;

public class UsersTest : IClassFixture<EnvFixture>
{
    public UsersTest()
    {
        
    }

    [Fact]
    public void RegisterUser()
    {
        ApplicationDbContext context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        UsersController controller = new();
        controller.Register("username", "password");
        User? u = controller.Login("username", "password");
        Assert.NotNull(u);
    }

    [Fact]
    public void LoginFailed()
    {
        ApplicationDbContext context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        UsersController controller = new();
        controller.Register("username", "password");
        User? u = controller.Login("username", "wrongpassword");
        Assert.Null(u);
    }

    [Fact]
    public void UnableToRegister()
    {
        ApplicationDbContext context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        UsersController controller = new();
        controller.Register("username", "password");
        User? u = controller.Register("username", "anotherpassword");
        Assert.Null(u);
    }
}