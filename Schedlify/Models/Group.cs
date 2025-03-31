namespace Schedlify.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Group
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long DepartmentId { get; set; }

    [Required]
    public long AdministratorId { get; set; }

    [Required]
    public string Name { get; set; }

    // Navigation properties
    [ForeignKey("DepartmentId")]
    public Department Department { get; set; }

    [ForeignKey("AdministratorId")]
    public User Administrator { get; set; }
    public ICollection<Assignment> Assignments { get; set; }
    public ICollection<Class> Classes { get; set; }
}
