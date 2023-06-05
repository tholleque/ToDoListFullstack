using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoListBackend.Models;

public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string? Name { get; set; }

    [Range(0, 40)]
    public int Hours { get; set; }

    [MaxLength(40)]
    public string? Title { get; set; }

    public virtual ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();
}
