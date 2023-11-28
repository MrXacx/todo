namespace todo.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TaskModel : IModel
{

    [ForeignKey(nameof(BoardModel))]
    public required int BoardId { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    [MinLength(10)]
    [MaxLength(300)]
    public required string Content { get; set; }
}
