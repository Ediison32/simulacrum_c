using Microsoft.VisualBasic;

namespace simulacro.Application.Models;

public class Users : Person
{
    public int Id { get; set; }
    
    public DateTime DateCreate { get; set; }
    
}