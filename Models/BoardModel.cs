namespace todo.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BoardModel : IModel
{

    [ForeignKey(nameof(UserModel))]
    public required int Owner { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    [MaxLength(30)]
    public required string Title { get; set; }

    [MaxLength(300)]
    public string? Description { get; set; }

    public List<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}
