namespace Schedlify.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Class
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid GroupId { get; set; }

    [Required]
    public string Name { get; set; }

    // Navigation properties
    [ForeignKey("GroupId")]
    public Group Group { get; set; }
    public ICollection<Assignment> Assignments { get; set; }
}