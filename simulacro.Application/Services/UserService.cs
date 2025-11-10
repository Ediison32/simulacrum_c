using simulacro.Application.Dto;
using simulacro.Application.Interfaces.Services;
using simulacro.Application.Models;
using simulacro.Domain.Interfaces;

namespace simulacro.Application.Services;

public class UserService : IUsersService
{
    
    // inyectar services de infrastructure 
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    
    
    
    public async Task<IEnumerable<UsersDto>> GetAllUserAsync()
    {
        var users = await _userRepository.GetAllUserAsync();

        return users.Select(u => new UsersDto
        {
            Id = u.Id,
            Name = u.Name,
            LastName = u.LastName,
            DocNumber = u.DocNumber,
            Email = u.Email,
            Phone = u.Phone,
            UserName = u.UserName,
            Password = u.Password,
            Role = u.Role,
            DateCreate = u.DateCreate

        });
    }

    public async Task<UsersDto> GetIdUserAsync(int id)
    {
        var user = await _userRepository.GetIdUserAsync(id);
        if (user == null) return null;

        return new UsersDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            DocNumber = user.DocNumber,
            Email = user.Email,
            Phone = user.Phone,
            UserName = user.UserName,
            Password = user.Password,
            Role = user.Role,
            DateCreate = user.DateCreate
        };

    }

    public async Task<UsersDto> AddUserAsync(UserCreateDto userDto)
    {
        // convierto un usercreateDto que creo el usuario, lo completo con 
        //un user para poder guardarlo en la db 
        var user = new Users
        {
            Name = userDto.Name,
            LastName = userDto.LastName,
            DocNumber = userDto.DocNumber,
            Email = userDto.Email,
            Phone = userDto.Phone,
            UserName = userDto.UserName,
            Password = userDto.Password,
            Role = Role.customer,
            DateCreate = DateTime.Now
        };

        await _userRepository.AddUserAsync(user);
        
        // devuelvo y muestro un tipo userDto para el user 
        return new UsersDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            DocNumber = user.DocNumber,
            Email = user.Email,
            Phone = user.Phone,
            UserName = user.UserName,
            Password = user.Password,
            Role = user.Role,
            DateCreate = user.DateCreate
        };
    }

    public async Task<UsersDto> UpdateUserAsync(int id, UserUpdateDto userDto)
    {
        var user = await _userRepository.GetIdUserAsync(id);
        if (user == null) return null;

        user.Name = userDto.Name;
        user.LastName = userDto.LastName;
        user.DocNumber = userDto.DocNumber;
        user.Email = userDto.Email;
        user.Phone = userDto.Phone;
        user.UserName = userDto.UserName;
        user.Password = userDto.Password;

        await _userRepository.UpdateUserAsync(user);
        
        // retorno un userDto para mostrar

        return new UsersDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            DocNumber = user.DocNumber,
            Email = user.Email,
            Phone = user.Phone,
            UserName = user.UserName,
            Password = user.Password,
            Role = user.Role,
            DateCreate = user.DateCreate
        };

    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteUserAsync(id);
    }
}