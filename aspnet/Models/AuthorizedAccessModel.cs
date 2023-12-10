namespace todo.Models;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class AuthorizedAccessModel : IModel
{

    [ForeignKey(nameof(UserModel))]
    public required int User { get; set; }

    [ForeignKey(nameof(BoardModel))]
    public required int Board { get; set; }

}
