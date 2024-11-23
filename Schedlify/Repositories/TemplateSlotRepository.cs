using Microsoft.EntityFrameworkCore;
using Schedlify.Data;
using Schedlify.Models;

namespace Schedlify.Repositories;

public class TemplateSlotRepository
{
    private readonly ApplicationDbContext _context;

    public TemplateSlotRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get template slot by department ID
    public IEnumerable<TemplateSlot> GetByDepartmentId(Guid departmentId)
    {
        return _context.TemplateSlots
            .Include(d => d.Department)         // Include the related university
            .Where(d => d.DepartmentId == departmentId).ToList();  // Find the department by ID
    }

    // Get template slot by department ID and class number
    public TemplateSlot? GetByDepartmentIdAndClassNumber(Guid departmentId, int classNumber)
    {
        return _context.TemplateSlots
            .Include(d => d.Department)         // Include the related university
            .FirstOrDefault(d => d.DepartmentId == departmentId && d.ClassNumber == classNumber);  // Find the department by ID
    }


    // Add a new TemplateSlot
    public TemplateSlot Add(Guid departmentId, TimeOnly startTime, TimeOnly endTime, int classNumber)
    {
        var templateSlot = new TemplateSlot
        {
            Id = Guid.NewGuid(),            // Generate a new GUID for the template slot
            DepartmentId = departmentId,    // Associate with a department
            StartTime = startTime,          // set a start time
            EndTime = endTime,              // set an end time
            ClassNumber = classNumber       // set a class number
        };

        _context.TemplateSlots.Add(templateSlot);  // Add template slot to the DbSet
        _context.SaveChanges();  // Save changes to the database

        return templateSlot;  // Return the added template slot
    }
}
