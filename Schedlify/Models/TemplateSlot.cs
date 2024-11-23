namespace Schedlify.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TemplateSlot
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid DepartmentId { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }

    [Required]
    public int ClassNumber { get; set; }

    // Navigation properties
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
}