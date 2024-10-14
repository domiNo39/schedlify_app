using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Schedlify.Models;

public class Schedule
{
    [Key]
    public Guid Id { get; set; }

    public Guid? ForkScheduleId { get; set; }
    public Schedule ForkSchedule { get; set; }

    [Required]
    public bool AutoUpdate { get; set; }

    [Required]
    public string Name { get; set; }

    [ForeignKey("Group")]
    public Guid GroupId { get; set; }
    public Group Group { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    public ICollection<ScheduleAssignment> ScheduleAssignments { get; set; }
    public ICollection<UserSchedule> UserSchedules { get; set; }
}