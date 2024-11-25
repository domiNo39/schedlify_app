namespace Schedlify.Tests.Controllers;


using Schedlify.Controllers;
using Schedlify.Models;
using Schedlify.Data;


public class UniversitiesTest : IClassFixture<EnvFixture>
{
    private readonly ApplicationDbContext _context;
    private readonly UniversityController _controller;

    public UniversitiesTest()
    {
        // Set up in-memory context for each test
        _context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        _controller = new UniversityController(_context);
    }

    [Fact]
    public void AddUniversity_ShouldAddUniversity_WhenDoesNotExist()
    {
        // Act
        var result = _controller.Add("Test University");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test University", result.Name);
    }

    [Fact]
    public void AddUniversity_ShouldReturnExistingUniversity_WhenAlreadyExists()
    {
        // Arrange
        _controller.Add("Existing University");

        // Act
        var result = _controller.Add("Existing University");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Existing University", result.Name);
        Assert.Single(_context.Universities); // Ensure no duplicate added
    }

    [Fact]
    public void SearchUniversity_ShouldReturnEmpty_WhenNoMatchFound()
    {
        // Arrange
        _controller.Add("Sample University");

        // Act
        var results = _controller.Search("Nonexistent");

        // Assert
        Assert.NotNull(results);
        Assert.Empty(results);
    }
}