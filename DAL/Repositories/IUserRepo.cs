using Core.Entities.User;

namespace DAL.Repositories
{
    public interface IUserRepo
    {
        ValueTask<User> AddAsync(User user);
        ValueTask DeleteAsync(Guid userId);
        IQueryable<User> GetAll();
        ValueTask<User?> GetByIdAsync(Guid userId);
        ValueTask<User?> GetByUsernameAsync(string username);
        ValueTask SaveChangesAsync();
        User Update(User user);
    }
}