namespace Schedlify.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Class
{
    [Key]
    public long Id { get; set; }

    [Required]
    public long GroupId { get; set; }

    [Required]
    public string Name { get; set; }

}