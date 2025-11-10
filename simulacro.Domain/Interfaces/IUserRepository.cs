using simulacro.Application.Models;

namespace simulacro.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<Users>> GetAllUserAsync();
    Task<Users> GetIdUserAsync(int id);
    Task<Users> AddUserAsync(Users user);
    Task<Users> UpdateUserAsync(int id, Users user);
    Task<Boolean> DeleteUserAsync(int id);

}