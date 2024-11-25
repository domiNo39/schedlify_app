using Microsoft.EntityFrameworkCore;
using Schedlify.Data;
using Schedlify.Models;

namespace Schedlify.Repositories;

public class AssignmentsRepository
{
    
    private readonly ApplicationDbContext _context;

    public AssignmentsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Assignment> GetAssignmentsByWeekday(Guid groupId, Weekday weekday, AssignmentType assignmentType)
    {
        return _context.Assignments
            .Include(d => d.Class)
            .Where(a => a.GroupId == groupId && a.Weekday == weekday)
            .Where(a => a.Type == assignmentType && a.Date == null)
            .OrderBy(a => a.StartTime)
            .ToList();
    }

    public IEnumerable<Assignment> GetAssignmentsByDate(Guid groupId, DateOnly date)
    {
        return _context.Assignments
            .Include(d => d.Class)
            .Where(a => a.GroupId == groupId && a.Date == date)
            .OrderBy(a => a.StartTime)
            .ToList();
    }
    
    public Assignment AddAssignment(
        Guid groupId,
        Guid classId,
        Weekday weekday,
        TimeOnly startTime,
        AssignmentType assignmentType, 
        string? lecturer = null,
        string? address = null,
        string? roomNumber = null,
        ClassType? classType = null,
        Mode? mode = null,
        DateOnly? date = null,
        TimeOnly? endTime = null
        )
    {
        // Ensure that required fields are provided (optional fields can be null)
        if (groupId == Guid.Empty || classId == Guid.Empty)
        {
            throw new ArgumentException("GroupId and ClassId must be valid GUIDs.");
        }

        // Create a new Assignment entity
        var assignment = new Assignment
        {
            Id = Guid.NewGuid(),
            GroupId = groupId,
            ClassId = classId,
            Weekday = weekday,
            StartTime = startTime,
            Type = assignmentType,
            Lecturer = lecturer,
            Address = address,
            RoomNumber = roomNumber,
            ClassType = classType,
            Mode = mode,
            Date = date,
            EndTime = endTime,
        };

        // Add the new assignment to the context
        _context.Assignments.Add(assignment);
        _context.SaveChanges();

        return assignment;
    }
    
    public void EditAssignment(
        Guid assignmentId,
        Guid classId,
        Weekday weekday,
        TimeOnly startTime,
        string? lecturer = null,
        string? address = null,
        string? roomNumber = null,
        ClassType? classType = null,
        Mode? mode = null,
        DateOnly? date = null,
        TimeOnly? endTime = null)
    {
        var assignment = _context.Assignments.FirstOrDefault(a => a.Id == assignmentId);
        
        if (assignment == null)
        {
            throw new InvalidOperationException("Assignment not found.");
        }

        assignment.ClassId = classId;
        assignment.Weekday = weekday;
        assignment.StartTime = startTime;
        assignment.Lecturer = lecturer;
        assignment.Address = address;
        assignment.RoomNumber = roomNumber;
        assignment.ClassType = classType;
        assignment.Mode = mode;
        assignment.Date = date;
        assignment.EndTime = endTime;

        _context.SaveChanges();
    }

    public void DeleteAssignment(Guid assignmentId)
    {
        var assignment = _context.Assignments.FirstOrDefault(a => a.Id == assignmentId);
        
        if (assignment == null)
        {
            throw new InvalidOperationException("Assignment not found.");
        }

        _context.Assignments.Remove(assignment);

        _context.SaveChanges();
    }
}