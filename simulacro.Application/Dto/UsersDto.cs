using simulacro.Application.Models;

namespace simulacro.Application.Dto;

public class UsersDto
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string LastName { get; set; } = string.Empty;
    public string DocNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; }
    public DateTime DateCreate { get; set; }
}

// create 

public class UserCreateDto
{
    public string Name { get; set; } 
    public string LastName { get; set; } = string.Empty;
    public string DocNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UserUpdateDto
{
    public string Name { get; set; } 
    public string LastName { get; set; } = string.Empty;
    public string DocNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}