namespace Schedlify.Tests.Controllers;

using Schedlify.Controllers;
using Schedlify.Models;
using Schedlify.Data;

public class GroupsTest : IClassFixture<EnvFixture>
{
    private readonly ApplicationDbContext _context;
    private readonly GroupController _controller;
    private readonly Guid _departmentId;

    public GroupsTest()
    {
        // Set up an in-memory context for each test
        _context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        _controller = new GroupController(_context);
        
        // Set up a department ID for testing
        _departmentId = Guid.NewGuid();

        // Add a sample department (this could be done via DepartmentController or direct insert if needed)
        _context.Departments.Add(new Department { Id = _departmentId, Name = "Computer Science", UniversityId = Guid.NewGuid() });
        _context.SaveChanges();
    }

    [Fact]
    public void AddGroup_ShouldAddGroup_WhenValidDataProvided()
    {
        // Arrange
        var administratorId = Guid.NewGuid();
        
        // Act
        var result = _controller.Add(_departmentId, administratorId, "Group A");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Group A", result.Name);
        Assert.Equal(_departmentId, result.DepartmentId);
        Assert.Equal(administratorId, result.AdministratorId);
    }

    // [Fact]
    // public void SearchGroup_ShouldReturnGroups_WhenPartialNameMatches()
    // {
    //     // Arrange
    //     var administratorId1 = Guid.NewGuid();
    //     var administratorId2 = Guid.NewGuid();
    //     _controller.Add(_departmentId, administratorId1, "Physics Group");
    //     _controller.Add(_departmentId, administratorId2, "Philosophy Group");
    //
    //     // Act
    //     var results = _controller.Search(_departmentId, "Phy");
    //
    //     // Assert
    //     Assert.NotNull(results);
    //     Assert.Equal(2, results.Count); // Expect 2 groups with "Phy" in name
    // }

    [Fact]
    public void SearchGroup_ShouldReturnEmpty_WhenNoMatchFound()
    {
        // Arrange
        _controller.Add(_departmentId, Guid.NewGuid(), "Biology Group");

        // Act
        var results = _controller.Search(_departmentId, "Nonexistent");

        // Assert
        Assert.NotNull(results);
        Assert.Empty(results);
    }

    [Fact]
    public void SearchGroup_ShouldReturnEmpty_WhenDepartmentIdDoesNotMatch()
    {
        // Arrange
        var otherDepartmentId = Guid.NewGuid();
        _controller.Add(_departmentId, Guid.NewGuid(), "Math Group");

        // Act
        var results = _controller.Search(otherDepartmentId, "Math");

        // Assert
        Assert.NotNull(results);
        Assert.Empty(results); // Should return empty because department ID does not match
    }

    [Fact]
    public void GetByAdministratorId_ShouldReturnGroup_WhenAdministratorIdMatches()
    {
        // Arrange
        var administratorId = Guid.NewGuid();
        _controller.Add(_departmentId, administratorId, "Chemistry Group");

        // Act
        var result = _controller.GetByAdministratorId(administratorId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Chemistry Group", result.Name);
        Assert.Equal(administratorId, result.AdministratorId);
    }

    [Fact]
    public void GetByAdministratorId_ShouldReturnNull_WhenAdministratorIdDoesNotMatch()
    {
        // Arrange
        var existingAdministratorId = Guid.NewGuid();
        _controller.Add(_departmentId, existingAdministratorId, "History Group");

        // Act
        var result = _controller.GetByAdministratorId(Guid.NewGuid()); // Nonexistent administrator ID

        // Assert
        Assert.Null(result);
    }
}