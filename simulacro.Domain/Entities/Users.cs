using Microsoft.VisualBasic;

namespace simulacro.Application.Models;

public class Users : Person
{
    public int Id { get; set; }
    
    public DateAndTime DateCreate { get; set; }
    
}