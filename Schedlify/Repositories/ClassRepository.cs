using Microsoft.EntityFrameworkCore;
using Schedlify.Data;
using Schedlify.Models;

namespace Schedlify.Repositories;

public class ClassRepository
{
    private readonly ApplicationDbContext _context;

    public ClassRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get template slot by department ID
    public IEnumerable<Class> GetByGroupId(Guid groupID)
    {
        return _context.Classes
            .Include(d => d.Group)        
            .Where(d => d.GroupId == groupID).ToList();
    }


    public Class Add(Guid groupId, string name)
    {
        var _class = new Class
        {
            Id = Guid.NewGuid(),  // Generate a new GUID for the department
            GroupId = groupId,  // Associate with a university
            Name = name
        };

        _context.Classes.Add(_class);  // Add department to the DbSet
        _context.SaveChanges();  // Save changes to the database

        return _class;  // Return the added department
    }

    public Class? EditById(Guid id, string name)
    {
        var _class = _context.Classes
            .Include(d => d.Group)
            .FirstOrDefault(d => d.Id == id);

        if (_class == null)
        {
            return null;
        }

        _class.Name = name;

        _context.SaveChanges();

        return _class;
    }

    public bool Remove(Guid id)
    {
        var _class = _context.Classes
            .Include(d => d.Group)
            .FirstOrDefault(d => d.Id == id);
        if (_class == null)
        {
            return false;
        }
        
        _context.Remove(_class);
        _context.SaveChanges();

        return true;
    }

}
