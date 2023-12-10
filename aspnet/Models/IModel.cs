namespace todo.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public abstract class IModel
{
    public int Id { get; set; }
}
