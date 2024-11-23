using Microsoft.EntityFrameworkCore;
using Schedlify.Data;
using Schedlify.Models;
using Schedlify.Repositories;

namespace Schedlify.Tests;

public class RepoTests
{
    private static ApplicationDbContext _context;

    public static void TestUserRepo()
    {
        _context = ApplicationDbContextFactory.CreateDbContext();
        using var transaction = _context.Database.BeginTransaction();

        UserRepository userRepository = new UserRepository(_context);
        userRepository.Add("admin@admin.com", "superhash");
        User? user = userRepository.GetByLogin("admin@admin.com");
        Console.WriteLine(user?.Login);

        transaction.Rollback(); // Roll back changes after test
    }

    public static void TestUniRepo()
    {
        _context = ApplicationDbContextFactory.CreateDbContext();
        using var transaction = _context.Database.BeginTransaction();

        UniversityRepository universityRepository = new UniversityRepository(_context);
        universityRepository.Add("Lviv National University");
        IEnumerable<University> universities = universityRepository.GetByNamePart("National");
        Console.WriteLine(universities.Any());

        transaction.Rollback(); // Roll back changes after test
    }

    public static void TestDepartmentRepo()
    {
        _context = ApplicationDbContextFactory.CreateDbContext();
        using var transaction = _context.Database.BeginTransaction();

        UniversityRepository universityRepository = new UniversityRepository(_context);
        DepartmentRepository departmentRepository = new DepartmentRepository(_context);

        var university = universityRepository.Add("Kyiv Polytechnic Institute");
        departmentRepository.Add(university.Id, "Mechanical Engineering Department");
        IEnumerable<Department> departments = departmentRepository.GetByNamePart("Engineering");
        Console.WriteLine(departments.Any());

        transaction.Rollback(); // Roll back changes after test
    }

    public static void TestGroupRepo()
    {
        _context = ApplicationDbContextFactory.CreateDbContext();
        using var transaction = _context.Database.BeginTransaction();
        
        UniversityRepository universityRepository = new UniversityRepository(_context);
        DepartmentRepository departmentRepository = new DepartmentRepository(_context);
        UserRepository userRepository = new UserRepository(_context);
        GroupRepository groupRepository = new GroupRepository(_context);
        universityRepository.Add("Lviv National University");
        IEnumerable<University> university = universityRepository.GetByNamePart("National");

        var department = departmentRepository.Add(university.First().Id, "Applied Math Faculty");
        var admin = userRepository.Add("groupadmin@university.com", "securehash");
        
        Group group = groupRepository.Add(department.Id, admin.Id, "PMI-35");
        group = groupRepository.GetById(group.Id);
        Console.WriteLine(group is not null);
        
        transaction.Rollback(); // Roll back changes after test
    }

    public static void TestClassRepo()
    {
        _context = ApplicationDbContextFactory.CreateDbContext();
        using var transaction = _context.Database.BeginTransaction();

        
        UniversityRepository universityRepository = new UniversityRepository(_context);
        DepartmentRepository departmentRepository = new DepartmentRepository(_context);
        UserRepository userRepository = new UserRepository(_context);
        GroupRepository groupRepository = new GroupRepository(_context);
        ClassRepository classRepository = new ClassRepository(_context);
        University u = universityRepository.Add("Lviv National University");
        Department d = departmentRepository.Add(u.Id, "Applied Math Faculty");
        User usr = userRepository.Add("groupadmin@university.com", "securehash");
        Group g = groupRepository.Add(d.Id, usr.Id, "PMI-35");
        Class c = classRepository.Add(g.Id, "Web Development");

        IEnumerable<Class> cs = classRepository.GetByGroupId(g.Id);
        Console.WriteLine(cs.Any());
        
        transaction.Rollback(); // Roll back changes after test
    }

    public static void TestAssRepo()
    {
        
        _context = ApplicationDbContextFactory.CreateDbContext();
        using var transaction = _context.Database.BeginTransaction();
        
        UniversityRepository universityRepository = new UniversityRepository(_context);
        DepartmentRepository departmentRepository = new DepartmentRepository(_context);
        UserRepository userRepository = new UserRepository(_context);
        GroupRepository groupRepository = new GroupRepository(_context);
        ClassRepository classRepository = new ClassRepository(_context);
        AssignmentsRepository assignmentsRepository = new AssignmentsRepository(_context);
        University u = universityRepository.Add("Lviv National University");
        Department d = departmentRepository.Add(u.Id, "Applied Math Faculty");
        User usr = userRepository.Add("groupadmin@university.com", "securehash");
        Group g = groupRepository.Add(d.Id, usr.Id, "PMI-35");
        Class c = classRepository.Add(g.Id, "Web Development");
        
        Assignment a = assignmentsRepository.AddAssignment(
            g.Id,
            c.Id,
            Weekday.Monday,
            new TimeOnly(15, 5),
            AssignmentType.Regular,
            "Tarasuk",
            "Universitetska, 1",
            "111",
            DateOnly.Parse("2021-01-01"),
            null
        );
        IEnumerable<Assignment> ass = assignmentsRepository.GetAssignmentsByWeekday(
            g.Id, Weekday.Monday, AssignmentType.Regular);
        Console.WriteLine(ass.Any());
        transaction.Commit();
        _context.SaveChanges();
    }

    public static void Run()
    {
        TestUserRepo();
        TestUniRepo();
        TestDepartmentRepo();
        TestGroupRepo();
        TestClassRepo();
        TestAssRepo();
    }
}
