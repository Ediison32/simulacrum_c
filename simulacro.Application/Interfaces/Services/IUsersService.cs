using simulacro.Application.Dto;
using simulacro.Application.Models;

namespace simulacro.Application.Interfaces.Services;

public interface IUsersService
{
    Task<IEnumerable<UsersDto>> GetAllUserAsync();
    Task<UsersDto> GetIdUserAsync(int id);
    Task<UsersDto> AddUserAsync(UserCreateDto userDto);
    Task<UsersDto> UpdateUserAsync(int id, UserUpdateDto userDto);
    Task<Boolean> DeleteUserAsync(int id);
}