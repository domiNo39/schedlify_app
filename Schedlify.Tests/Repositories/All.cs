namespace Schedlify.Tests.Repositories;

using System;
using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;
using Xunit;

public class RepoUnitTests : IClassFixture<EnvFixture>
{
    private EnvFixture _fixture;
    private ApplicationDbContext _context;
    private UserRepository _userRepository;
    private UniversityRepository _universityRepository;
    private DepartmentRepository _departmentRepository;
    private GroupRepository _groupRepository;
    private ClassRepository _classRepository;
    private AssignmentsRepository _assignmentsRepository;

    private void RecreateDbContext()
    {
        this._context = DesignTimeDbContextFactory.CreateInMemoryDbContext(); // This assumes you have an in-memory database for testing
        this._userRepository = new UserRepository(this._context);
        this._universityRepository = new UniversityRepository(this._context);
        this._departmentRepository = new DepartmentRepository(this._context);
        this._groupRepository = new GroupRepository(this._context);
        this._classRepository = new ClassRepository(this._context);
        this._assignmentsRepository = new AssignmentsRepository(this._context);
    }

    // Constructor for setting up the context and repositories
    public RepoUnitTests(EnvFixture fixture)
    {
        this._fixture = fixture;
        RecreateDbContext();
    }

    // Dispose method to clean up after tests
    public void Dispose()
    {
        this._context?.Dispose();
    }

    [Fact]
    public void TestUserRepo()
    {
        RecreateDbContext();
        // Arrange
        _userRepository.Add("admin@admin.com", "superhash");

        // Act
        User? user = _userRepository.GetByLogin("admin@admin.com");

        // Assert
        Assert.NotNull(user);
        Assert.Equal("admin@admin.com", user?.Login);
    }

    [Fact]
    public void TestUniRepo()
    {
        RecreateDbContext();
        // Arrange
        _universityRepository.Add("Lviv National University");

        // Act
        var universities = _universityRepository.GetByNamePart("National");

        // Assert
        Assert.NotEmpty(universities);
    }

    [Fact]
    public void TestDepartmentRepo()
    {
        RecreateDbContext();
        // Arrange
        var university = _universityRepository.Add("Kyiv Polytechnic Institute");
        _departmentRepository.Add(university.Id, "Mechanical Engineering Department");

        // Act
        var departments = _departmentRepository.GetByNamePart("Engineering");

        // Assert
        Assert.NotEmpty(departments);
    }

    [Fact]
    public void TestGroupRepo()
    {
        RecreateDbContext();
        // Arrange
        var university = _universityRepository.Add("Lviv National University");
        var department = _departmentRepository.Add(university.Id, "Applied Math Faculty");
        var admin = _userRepository.Add("groupadmin@university.com", "securehash");
        var group = _groupRepository.Add(department.Id, admin.Id, "PMI-35");

        // Act
        var groupFromDb = _groupRepository.GetById(group.Id);

        // Assert
        Assert.NotNull(groupFromDb);
    }

    [Fact]
    public void TestClassRepo()
    {
        RecreateDbContext();
        // Arrange
        var university = _universityRepository.Add("Lviv National University");
        var department = _departmentRepository.Add(university.Id, "Applied Math Faculty");
        var user = _userRepository.Add("groupadmin@university.com", "securehash");
        var group = _groupRepository.Add(department.Id, user.Id, "PMI-35");
        var classEntity = _classRepository.Add(group.Id, "Web Development");

        // Act
        var classes = _classRepository.GetByGroupId(group.Id);

        // Assert
        Assert.NotEmpty(classes);
    }

    [Fact]
    public void TestAssRepo()
    {
        RecreateDbContext();
        // Arrange
        var university = _universityRepository.Add("Lviv National University");
        var department = _departmentRepository.Add(university.Id, "Applied Math Faculty");
        var user = _userRepository.Add("groupadmin@university.com", "securehash");
        var group = _groupRepository.Add(department.Id, user.Id, "PMI-35");
        var classEntity = _classRepository.Add(group.Id, "Web Development");

        
        Assignment a = _assignmentsRepository.AddAssignment(
            group.Id,
            classEntity.Id,
            Weekday.Monday,
            new TimeOnly(15, 5),
            AssignmentType.Regular,
            "Tarasuk",
            "Universitetska, 1",
            "111", null, null,
            null,
            null
        );

        var assignments = _assignmentsRepository.GetAssignmentsByWeekday(group.Id, Weekday.Monday, AssignmentType.Regular);

        // Assert
        Assert.NotEmpty(assignments);
    }
}