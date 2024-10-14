using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Schedlify.Models;

public class ScheduleAssignment
{
    [ForeignKey("Assignment")]
    public Guid AssignmentId { get; set; }
    public Assignment Assignment { get; set; }

    [ForeignKey("Schedule")]
    public Guid ScheduleId { get; set; }
    public Schedule Schedule { get; set; }
}