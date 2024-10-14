using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Schedlify.Models;

public class UserSchedule
{
    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [ForeignKey("Schedule")]
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; }

    [Required]
    public bool Notify { get; set; }
}