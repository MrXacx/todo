namespace todo.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class TaskModel
{
    public int? Id { get; set; }
    public int? Author { get; set; }
    public DateTime? Date { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }

}
