namespace Schedlify.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Assignment
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid GroupId { get; set; }

    [Required]
    public Guid ClassId { get; set; }

    public ClassType? ClassType { get; set; }
    public Mode? Mode { get; set; }

    [Required]
    public Weekday Weekday { get; set; }

    public string Lecturer { get; set; }
    public string Address { get; set; }
    public string RoomNumber { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    [Required]
    [Column("Type")]
    public AssignmentType Type { get; set; }
        
    [Column("Date")]
    public DateTime? Date { get; set; }

    // Navigation properties
    [ForeignKey("GroupId")]
    public Group Group { get; set; }

    [ForeignKey("ClassId")]
    public Class Class { get; set; }
}