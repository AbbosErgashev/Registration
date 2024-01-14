using Microsoft.EntityFrameworkCore;
using Registration.Infrastructure.Data;
using Registration.Infrastructure.Entities;
using Registration.Infrastructure.IRepositories;

namespace Registration.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDataContext _context;

    public UserRepository(AppDataContext context) => _context = context;

    public async Task CreateUser(User user)
    {
        if (user is null) throw new ArgumentNullException(nameof(user));

        await _context.Users.AddAsync(user);
    }

    public void DeleteUser(User user)
    {
        if (user is null) throw new ArgumentNullException(nameof(user));

        _context.Users.Remove(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();

    public async Task<User> GetUserById(int id)
        => await _context.Users.FirstOrDefaultAsync(user => user.Id == id) ?? throw new ArgumentNullException();

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

    public async Task UpdateUser(User user)
    {
        if(user is null) throw new ArgumentNullException( nameof(user));

        await _context.SaveChangesAsync();
    }
}
