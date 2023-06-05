using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListBackend.Models;

public partial class ToDo
{
    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string? Name { get; set; }

    [MaxLength(100)]
    public string? Description { get; set; }

    [ForeignKey("Employee")]
    public int? AssignedTo { get; set; }

    public int? HoursNeeded { get; set; }
    
    public bool? IsCompleted { get; set; }

    public virtual Employee? AssignedToNavigation { get; set; }
}
