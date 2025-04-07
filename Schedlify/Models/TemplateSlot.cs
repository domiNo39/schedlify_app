namespace Schedlify.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TemplateSlot
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long DepartmentId { get; set; }

    [Required]
    public TimeOnly StartTime { get; set; }

    [Required]
    public TimeOnly EndTime { get; set; }

    [Required]
    public int ClassNumber { get; set; }
}