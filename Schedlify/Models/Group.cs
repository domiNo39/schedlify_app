using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Schedlify.Models;

public class Group
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("University")]
    public Guid UniversityId { get; set; }
    public University University { get; set; }

    [ForeignKey("Department")]
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }

    [ForeignKey("Administrator")]
    public Guid AdministratorId { get; set; }
    public User Administrator { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Class> Classes { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
}