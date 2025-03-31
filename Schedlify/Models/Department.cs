namespace Schedlify.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Department
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long UniversityId { get; set; }

    [Required]
    [StringLength(64)]
    public string Name { get; set; }

    // Navigation properties
    [ForeignKey("UniversityId")]
    public University University { get; set; }
    public ICollection<Group> Groups { get; set; }
    public ICollection<TemplateSlot> TemplateSlots { get; set; }
}