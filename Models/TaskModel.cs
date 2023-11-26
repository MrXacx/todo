namespace todo.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

public class TaskModel
{
    public int Id { get; set; }

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
