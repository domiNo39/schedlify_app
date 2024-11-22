using Microsoft.EntityFrameworkCore;
using Schedlify.Data;
using Schedlify.Models;

namespace Schedlify.Repositories;

public class UniversityRepository
{
    private readonly ApplicationDbContext _context;

    public UniversityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get university by ID
    public University? GetById(Guid universityId)
    {
        return _context.Universities
            .Include(u => u.Departments)  // Include related departments
            .FirstOrDefault(u => u.Id == universityId);  // Find the university by ID
    }

    // Get university by Name
    public University? GetByName(string name)
    {
        return _context.Universities
            .Include(u => u.Departments)  // Include related departments
            .FirstOrDefault(u => u.Name == name);  // Find the university by ID
    }

    // Get university by name

    public IEnumerable<University> GetByNamePart(string name)
    {
        return _context.Universities
            .Include(u => u.Departments)
            .Where(u => u.Name.ToLower().Contains(name.ToLower()))
            .ToList(); // Search by name substring=
    }

    // Add a new university
    public University Add(string name)
    {
        var university = new University
        {
            Id = Guid.NewGuid(),  // Generate a new GUID for the university
            Name = name
        };

        _context.Universities.Add(university);  // Add the university to the DbSet
        _context.SaveChanges();  // Save changes to the database

        return university;  // Return the added university
    }
}