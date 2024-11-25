namespace Schedlify.Tests.Controllers;

using Schedlify.Controllers;
using Schedlify.Repositories;
using Schedlify.Models;
using Schedlify.Data;


public class AssignmentsRepoTest : IClassFixture<EnvFixture>
{
    private readonly ApplicationDbContext _context;
    private readonly AssignmentsRepository _repository;
    private readonly Guid _groupId;
    private readonly Guid _classId;

    public AssignmentsRepoTest()
    {
        // Set up an in-memory context for each test
        _context = DesignTimeDbContextFactory.CreateInMemoryDbContext();
        _repository = new AssignmentsRepository(_context);

        // Set up sample data for Group and Class
        _groupId = Guid.NewGuid();
        _classId = Guid.NewGuid();

        _context.Groups.Add(new Group { Id = _groupId, Name = "Group A", DepartmentId = Guid.NewGuid() });
        _context.Classes.Add(new Class { Id = _classId, Name = "Math Class", GroupId = _groupId });
        _context.SaveChanges();
    }

    [Fact]
    public void GetAssignmentsByWeekday_ShouldReturnAssignments_WhenAssignmentsExistForWeekday()
    {
        // Arrange
        _repository.AddAssignment(
            _groupId,
            _classId,
            Weekday.Monday,
            new TimeOnly(9, 0),
            AssignmentType.Regular
        );
        _repository.AddAssignment(
            _groupId,
            _classId,
            Weekday.Monday,
            new TimeOnly(11, 0),
            AssignmentType.Regular
        );

        // Act
        var assignments = _repository.GetAssignmentsByWeekday(_groupId, Weekday.Monday, AssignmentType.Regular);

        // Assert
        Assert.NotNull(assignments);
        Assert.Equal(2, assignments.Count()); // Expect 2 assignments for Monday
    }

    [Fact]
    public void GetAssignmentsByWeekday_ShouldReturnEmptyList_WhenNoAssignmentsExistForWeekday()
    {
        // Act
        var assignments = _repository.GetAssignmentsByWeekday(_groupId, Weekday.Tuesday, AssignmentType.Regular);

        // Assert
        Assert.NotNull(assignments);
        Assert.Empty(assignments); // Should return an empty list
    }

    [Fact]
    public void GetAssignmentsByDate_ShouldReturnAssignments_WhenAssignmentsExistForDate()
    {
        // Arrange
        var date = new DateOnly(2024, 11, 25);
        _repository.AddAssignment(
            _groupId,
            _classId,
            Weekday.Monday,
            new TimeOnly(9, 0),
            AssignmentType.Regular,
            date: date
        );

        // Act
        var assignments = _repository.GetAssignmentsByDate(_groupId, date);

        // Assert
        Assert.NotNull(assignments);
        Assert.Single(assignments); // Expect 1 assignment for the specified date
    }

    [Fact]
    public void AddAssignment_ShouldAddAssignment_WhenValidDataProvided()
    {
        // Act
        var assignment = _repository.AddAssignment(
            _groupId,
            _classId,
            Weekday.Monday,
            new TimeOnly(10, 0),
            AssignmentType.Regular
        );

        // Assert
        Assert.NotNull(assignment);
        Assert.Equal(_groupId, assignment.GroupId);
        Assert.Equal(_classId, assignment.ClassId);
        Assert.Equal(Weekday.Monday, assignment.Weekday);
        Assert.Equal(AssignmentType.Regular, assignment.Type);
    }

    [Fact]
    public void EditAssignment_ShouldUpdateAssignment_WhenValidDataProvided()
    {
        // Arrange
        var assignment = _repository.AddAssignment(
            _groupId,
            _classId,
            Weekday.Monday,
            new TimeOnly(10, 0),
            AssignmentType.Regular
        );

        // Act
        _repository.EditAssignment(
            assignment.Id,
            _classId,
            Weekday.Tuesday,
            new TimeOnly(11, 0),
            "New Regularr",
            "New Address",
            "Room 101"
        );

        // Assert
        var updatedAssignment = _context.Assignments.Find(assignment.Id);
        Assert.NotNull(updatedAssignment);
        Assert.Equal(Weekday.Tuesday, updatedAssignment.Weekday);
        Assert.Equal("New Regularr", updatedAssignment.Lecturer);
        Assert.Equal("New Address", updatedAssignment.Address);
        Assert.Equal("Room 101", updatedAssignment.RoomNumber);
    }

    [Fact]
    public void EditAssignment_ShouldThrowException_WhenAssignmentDoesNotExist()
    {
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            _repository.EditAssignment(Guid.NewGuid(), _classId, Weekday.Monday, new TimeOnly(9, 0), "Regularr")
        ); // Should throw InvalidOperationException if assignment not found
    }

    [Fact]
    public void DeleteAssignment_ShouldRemoveAssignment_WhenAssignmentExists()
    {
        // Arrange
        var assignment = _repository.AddAssignment(
            _groupId,
            _classId,
            Weekday.Monday,
            new TimeOnly(10, 0),
            AssignmentType.Regular
        );

        // Act
        _repository.DeleteAssignment(assignment.Id);

        // Assert
        var deletedAssignment = _context.Assignments.Find(assignment.Id);
        Assert.Null(deletedAssignment); // Assignment should be removed from the database
    }

    [Fact]
    public void DeleteAssignment_ShouldThrowException_WhenAssignmentDoesNotExist()
    {
        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            _repository.DeleteAssignment(Guid.NewGuid()) // Non-existent assignment ID
        ); // Should throw InvalidOperationException if assignment not found
    }
}