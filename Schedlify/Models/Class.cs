using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Schedlify.Models;

public class Class
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("Group")]
    public Guid GroupId { get; set; }
    public Group Group { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }
    public User User { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Assignment> Assignments { get; set; }
}