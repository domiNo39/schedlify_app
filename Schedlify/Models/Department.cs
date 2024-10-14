using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Schedlify.Models;

public class Department
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("University")]
    public Guid UniversityId { get; set; }
    public University University { get; set; }
    
    [Required, MaxLength(64)]
    public string Name { get; set; }
    
    [Required]
    public string Position { get; set; }  // Assuming Position is a string field

    public ICollection<Group> Groups { get; set; }
    public ICollection<TemplateSlot> TemplateSlots { get; set; }
}