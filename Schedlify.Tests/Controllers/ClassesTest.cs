namespace Schedlify.Tests.Controllers;

using Schedlify.Controllers;
using Schedlify.Models;
using Schedlify.Data;

public class ClassesTest : IClassFixture<EnvFixture>
{
    private readonly ApplicationDbContext _context;
    private readonly ClassController _controller;
    private readonly Guid _groupId;

    public ClassesTest()
    {
        // Set up an in-memory context for each test
        _context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        _controller = new ClassController(_context);
        
        // Set up a group ID for testing
        _groupId = Guid.NewGuid();

        // Add a sample group (this could be done via GroupController or direct insert if needed)
        _context.Groups.Add(new Group { Id = _groupId, Name = "Group A", DepartmentId = Guid.NewGuid() });
        _context.SaveChanges();
    }

    [Fact]
    public void AddClass_ShouldAddClass_WhenValidDataProvided()
    {
        // Act
        var result = _controller.Add(_groupId, "Math Class");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Math Class", result.Name);
        Assert.Equal(_groupId, result.GroupId);
    }

    [Fact]
    public void GetByGroupId_ShouldReturnClasses_WhenClassesExistForGroup()
    {
        // Arrange
        _controller.Add(_groupId, "Physics Class");
        _controller.Add(_groupId, "Chemistry Class");

        // Act
        var results = _controller.GetByGroupId(_groupId);

        // Assert
        Assert.NotNull(results);
        Assert.Equal(2, results.Count); // Expect 2 classes for the group
    }

    [Fact]
    public void GetByGroupId_ShouldReturnEmptyList_WhenNoClassesExistForGroup()
    {
        // Act
        var results = _controller.GetByGroupId(Guid.NewGuid()); // Non-existent group ID

        // Assert
        Assert.NotNull(results);
        Assert.Empty(results); // Should return an empty list
    }

    [Fact]
    public void EditClass_ShouldUpdateClassName_WhenValidDataProvided()
    {
        // Arrange
        var newClass = _controller.Add(_groupId, "Biology Class");

        // Act
        var result = _controller.Edit(newClass.Id, "Advanced Biology");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Advanced Biology", result.Name);
        Assert.Equal(newClass.Id, result.Id);
    }

    [Fact]
    public void EditClass_ShouldReturnNull_WhenClassIdDoesNotExist()
    {
        // Act
        var result = _controller.Edit(Guid.NewGuid(), "Nonexistent Class");

        // Assert
        Assert.Null(result); // Should return null if the class ID doesn't exist
    }

    [Fact]
    public void DeleteClass_ShouldReturnTrue_WhenClassExists()
    {
        // Arrange
        var newClass = _controller.Add(_groupId, "History Class");

        // Act
        var result = _controller.Delete(newClass.Id);

        // Assert
        Assert.True(result); // Should return true if deletion was successful
        Assert.Null(_context.Classes.Find(newClass.Id)); // Verify that the class was removed from the database
    }

    [Fact]
    public void DeleteClass_ShouldReturnFalse_WhenClassIdDoesNotExist()
    {
        // Act
        var result = _controller.Delete(Guid.NewGuid()); // Non-existent class ID

        // Assert
        Assert.False(result); // Should return false if the class ID does not exist
    }
}