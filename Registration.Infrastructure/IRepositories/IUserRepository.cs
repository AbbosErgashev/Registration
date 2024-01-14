using Registration.Infrastructure.Entities;

namespace Registration.Infrastructure.IRepositories;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<User> GetUserById(int id);
    public Task CreateUser(User user);
    public void DeleteUser(User user);
    public Task UpdateUser(User user);
    public Task<bool> SaveChangesAsync();
}
