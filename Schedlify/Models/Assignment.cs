using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Schedlify.Models;

public class Assignment
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("Class")]
    public Guid ClassId { get; set; }
    public Class Class { get; set; }

    [Required]
    public string ClassType { get; set; }  // lecture/seminar

    [Required]
    public string Mode { get; set; }  // online/offline

    [Required]
    public string Weekday { get; set; }

    public string? Lecturer { get; set; }
    public string? Building { get; set; }
    public string? RoomNumber { get; set; }

    [Required]
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    [Required]
    public string Type_ { get; set; }  // enum: special/chyselnyk/znamennyk 

    public DateTime? Date_ { get; set; }

    public ICollection<ScheduleAssignment> ScheduleAssignments { get; set; }
}