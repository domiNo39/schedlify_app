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
            .Where(a => a.GroupId == groupId && a.Weekday == weekday)
            .Where(a => a.Type == assignmentType)
            .OrderBy(a => a.StartTime)
            .ToList();
    }

    public IEnumerable<Assignment> GetAssignmentsByDate(Guid groupId, DateOnly date)
    {
        return _context.Assignments
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
        DateOnly? date = null,
        TimeOnly? endTime = null
        )
    {
        // Ensure that required fields are provided (optional fields can be null)
        if (groupId == Guid.Empty || classId == Guid.Empty)
        {
            throw new ArgumentException("GroupId and ClassId must be valid GUIDs.");
        }

        // Optionally: Check if the assignment already exists based on specific criteria (e.g., same group, weekday, time)
        bool assignmentExists = _context.Assignments.Any(a => a.GroupId == groupId && 
                                                              a.Weekday == weekday && 
                                                              a.StartTime == startTime);

        if (assignmentExists)
        {
            throw new InvalidOperationException("An assignment for this group, weekday, and start time already exists.");
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
            Date = date,
            EndTime = endTime
        };

        // Add the new assignment to the context
        _context.Assignments.Add(assignment);

        return assignment;
    }
    
    public void EditAssignment(Guid assignmentId, Guid groupId, Guid classId, Weekday weekday, TimeOnly startTime, AssignmentType assignmentType, 
                               string? lecturer = null, string? address = null, string? roomNumber = null, DateOnly? date = null, TimeOnly? endTime = null)
    {
        var assignment = _context.Assignments.FirstOrDefault(a => a.Id == assignmentId);
        
        if (assignment == null)
        {
            throw new InvalidOperationException("Assignment not found.");
        }

        assignment.GroupId = groupId;
        assignment.ClassId = classId;
        assignment.Weekday = weekday;
        assignment.StartTime = startTime;
        assignment.Type = assignmentType;
        assignment.Lecturer = lecturer;
        assignment.Address = address;
        assignment.RoomNumber = roomNumber;
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