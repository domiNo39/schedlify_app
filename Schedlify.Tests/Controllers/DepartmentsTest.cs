namespace Schedlify.Tests.Controllers;


using Schedlify.Controllers;
using Schedlify.Models;
using Schedlify.Data;


public class DepartmentsTest: IClassFixture<EnvFixture>
{
    private readonly ApplicationDbContext _context;
    private readonly DepartmentController _controller;
    private readonly Guid _universityId;

    public DepartmentsTest()
    {
        // Set up an in-memory context for each test
        _context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        _controller = new DepartmentController(_context);
        
        // Set up a university ID for testing
        _universityId = Guid.NewGuid();

        // Add a sample university (this could be done via UniversityController or direct insert if needed)
        _context.Universities.Add(new University { Id = _universityId, Name = "Test University" });
        _context.SaveChanges();
    }

    [Fact]
    public void AddDepartment_ShouldAddDepartment_WhenDoesNotExist()
    {
        // Act
        var result = _controller.Add(_universityId, "Computer Science");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Computer Science", result.Name);
        Assert.Equal(_universityId, result.UniversityId);
    }

    [Fact]
    public void AddDepartment_ShouldReturnExistingDepartment_WhenAlreadyExists()
    {
        // Arrange
        _controller.Add(_universityId, "Mathematics");

        // Act
        var result = _controller.Add(_universityId, "Mathematics");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Mathematics", result.Name);
        Assert.Equal(_universityId, result.UniversityId);
        Assert.Single(_context.Departments); // Ensure no duplicate was added
    }

    [Fact]
    public void SearchDepartment_ShouldReturnDepartments_WhenPartialNameMatches()
    {
        // Arrange
        _controller.Add(_universityId, "Physics");
        _controller.Add(_universityId, "Chemistry");
        _controller.Add(_universityId, "Philosophy");

        // Act
        var results = _controller.Search(_universityId, "Ph");

        // Assert
        Assert.NotNull(results);
        Assert.Equal(2, results.Count); // Expect 2 departments with "Ph" in name
    }

    [Fact]
    public void SearchDepartment_ShouldReturnEmpty_WhenNoMatchFound()
    {
        // Arrange
        _controller.Add(_universityId, "Biology");

        // Act
        var results = _controller.Search(_universityId, "Nonexistent");

        // Assert
        Assert.NotNull(results);
        Assert.Empty(results);
    }

    [Fact]
    public void SearchDepartment_ShouldReturnEmpty_WhenUniversityIdDoesNotMatch()
    {
        // Arrange
        var otherUniversityId = Guid.NewGuid();
        _controller.Add(_universityId, "History");

        // Act
        var results = _controller.Search(otherUniversityId, "History");

        // Assert
        Assert.NotNull(results);
        Assert.Empty(results); // Should return empty because university ID does not match
    }
}