using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Schedlify.Models;


// Users Model
public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required, MaxLength(32)]
    public string Login { get; set; }

    [Required]
    public string PasswordHash { get; set; }
    
    [Required]
    public long TgId { get; set; }
    
    [MaxLength(32)]
    public string Username { get; set; }

    [Required, MaxLength(64)]
    public string FirstName { get; set; }

    [MaxLength(64)]
    public string LastName { get; set; }

    public ICollection<Group> AdminGroups { get; set; }
    public ICollection<TemplateSlot> TemplateSlots { get; set; }
    public ICollection<Schedule> Schedules { get; set; }
    public ICollection<UserSchedule> UserSchedules { get; set; }
    public ICollection<Class> Classes { get; set; }
}