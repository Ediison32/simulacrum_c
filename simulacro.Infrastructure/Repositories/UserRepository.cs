using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using simulacro.Application.Models;
using simulacro.Domain.Interfaces;
using simulacro.Infrastructure.Data;

namespace simulacro.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    // inicializar la db 
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Users>> GetAllUserAsync()
    {
        try
        {
            return await _context.users.ToListAsync();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Users> GetIdUserAsync(int id)
    {
        var userId = await _context.users.FindAsync(id);
        if (userId == null) return null;

        return userId;
    }

    public async Task<Users> AddUserAsync(Users user)
    {
        var userid = await _context.users.FindAsync(user.Id);
        if (userid != null) return null;
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~eNTRO A CREAR ***************************");
        _context.users.AddAsync(user);
        await _context.SaveChangesAsync();
        return userid;

    }

    public async Task<Users> UpdateUserAsync(Users user)
    {
        try
        {
            user.Name = user.Name;
            user.LastName = user.LastName;
            user.DocNumber = user.DocNumber;
            user.Phone = user.Phone;
            user.Email = user.Email;
            user.UserName = user.UserName;
            user.Password = user.Password;

            await _context.SaveChangesAsync();
            return user;

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        try
        {
            var userid = await _context.users.FindAsync(id);
            if (userid == null) return false;
            _context.Remove(userid);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}