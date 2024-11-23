using Microsoft.EntityFrameworkCore;
using Schedlify.Data;
using Schedlify.Models;

namespace Schedlify.Repositories;

public class DepartmentRepository
{
    private readonly ApplicationDbContext _context;

    public DepartmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get department by ID
    public Department? GetById(Guid departmentId)
    {
        return _context.Departments
            .Include(d => d.University)         // Include the related university
            .Include(d => d.Groups)             // Include related groups
            .Include(d => d.TemplateSlots)      // Include related template slots
            .FirstOrDefault(d => d.Id == departmentId);  // Find the department by ID
    }

    // Get departments by university ID
    public IEnumerable<Department> GetByUniversityId(Guid universityId)
    {
        return _context.Departments
            .Include(d => d.Groups)
            .Include(d => d.TemplateSlots)
            .Where(d => d.UniversityId == universityId)
            .ToList();  // Retrieve departments by university ID
    }

    // Get departments by name part (substring search)
    public IEnumerable<Department> GetByNamePart(string name)
    {
        return _context.Departments
            .Include(d => d.University)
            .Include(d => d.Groups)
            .Include(d => d.TemplateSlots)
            .Where(d => d.Name.ToLower().Contains(name.ToLower())) // Search by name substring
            .ToList();
    }

    // Get departments by name part and uni ID
    public IEnumerable<Department> GetByNamePartAndUniversityId(Guid universityId, string name)
    {
        return _context.Departments
            .Include(d => d.Groups)
            .Include(d => d.TemplateSlots)
            .Where(d => d.UniversityId == universityId & d.Name.ToLower().Contains(name.ToLower()))
            .ToList();
    }
    public Department? GetByNameAndUniversityId(Guid universityId, string name)
    {
        return _context.Departments
            .Include(d => d.Groups)
            .Include(d => d.TemplateSlots)
            .FirstOrDefault(d => d.UniversityId == universityId & d.Name == name); 
    }


    // Add a new department
    public Department Add(Guid universityId, string name)
    {
        var department = new Department
        {
            Id = Guid.NewGuid(),  // Generate a new GUID for the department
            UniversityId = universityId,  // Associate with a university
            Name = name
        };

        _context.Departments.Add(department);  // Add department to the DbSet
        _context.SaveChanges();  // Save changes to the database

        return department;  // Return the added department
    }
}
