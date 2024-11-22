using Microsoft.EntityFrameworkCore;
using Schedlify.Data;
using Schedlify.Models;

namespace Schedlify.Repositories;

public class GroupRepository
{
    private readonly ApplicationDbContext _context;

    public GroupRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get group by ID
    public Group? GetById(Guid groupId)
    {
        return _context.Groups
            .Include(g => g.Department)       // Include the related department
            .Include(g => g.Administrator)    // Include the related administrator
            .Include(g => g.Assignments)      // Include related assignments
            .Include(g => g.Classes)          // Include related classes
            .FirstOrDefault(g => g.Id == groupId);  // Find the group by ID
    }

    // Get groups by department ID
    public IEnumerable<Group> GetByDepartmentId(Guid departmentId)
    {
        return _context.Groups
            .Include(g => g.Administrator)
            .Include(g => g.Assignments)
            .Include(g => g.Classes)
            .Where(g => g.DepartmentId == departmentId)
            .ToList();  // Retrieve groups by department ID
    }

    // Get groups by administrator ID
    public Group? GetByAdministratorId(Guid administratorId)
    {
        return _context.Groups
            .Include(g => g.Department)
            .Include(g => g.Assignments)
            .Include(g => g.Classes)
            .FirstOrDefault(g => g.AdministratorId == administratorId);
    }

    // Get groups by name part (substring search)
    public IEnumerable<Group> GetByNamePartAndDepartmentId(string name, Guid departmentId)
    {
        return _context.Groups
            .Include(g => g.Department)
            .Include(g => g.Administrator)
            .Include(g => g.Assignments)
            .Include(g => g.Classes)
            .Where(g => g.Name.ToLower().Contains(name.ToLower()))
            .Where(g => g.DepartmentId == departmentId)// Search by name substring
            .ToList();
    }

    // Add a new group
    public Group Add(Guid departmentId, Guid administratorId, string name)
    {
        var group = new Group
        {
            Id = Guid.NewGuid(),         // Generate a new GUID for the group
            DepartmentId = departmentId, // Associate with a department
            AdministratorId = administratorId, // Associate with an administrator
            Name = name
        };

        _context.Groups.Add(group);     // Add the group to the DbSet
        _context.SaveChanges();         // Save changes to the database

        return group;  // Return the added group
    }
}