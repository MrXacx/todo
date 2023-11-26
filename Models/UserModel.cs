namespace todo.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Index(propertyNames: ["Email"], IsUnique = true, Name = "IX_User_Email")]
public class UserModel
{
    public int Id { get; set; }

    [MinLength(3)]
    [MaxLength(30)]
    public required string Name { get; set; }


    public required string Email { get; set; }

    [MinLength(6)]
    [MaxLength(35)]
    public required string Password { get; set; }

    public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}
