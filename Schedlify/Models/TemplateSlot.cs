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
    public TimeSpan StartTime { get; set; }

    [Required]
    public TimeSpan EndTime { get; set; }

    [Required]
    public int ClassNumber { get; set; }

    // Navigation properties
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }
}