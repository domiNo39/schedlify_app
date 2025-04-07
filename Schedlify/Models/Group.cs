//COPYRIGHT NIGGERCODE
namespace Schedlify.Models;
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

}