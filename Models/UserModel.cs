namespace todo.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

[Index(propertyNames: ["Email"], IsUnique = true, Name = "IX_User_Email")]
public class UserModel : IModel
{

    [MinLength(3)]
    [MaxLength(30)]
    public string? Name { get; set; }

    public required string Email { get; set; }

    [MinLength(6)]
    [MaxLength(35)]
    public required string Password { get; set; }

    public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}
