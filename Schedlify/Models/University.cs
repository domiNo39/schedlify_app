using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace Schedlify.Models;

public class University
{
    [Key]
    public Guid Id { get; set; }
    
    [Required, MaxLength(64)]
    public string Name { get; set; }

    public ICollection<Department> Departments { get; set; }
    public ICollection<Group> Groups { get; set; }
}