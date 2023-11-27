namespace todo.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TaskModel : IModel
{

    [ForeignKey(nameof(UserModel))]
    public required int AuthorId { get; set; }

    public required UserModel Author { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    [MinLength(3)]
    [MaxLength(30)]
    public required string Title { get; set; }

    [MinLength(10)]
    [MaxLength(300)]
    public required string Text { get; set; }
}
