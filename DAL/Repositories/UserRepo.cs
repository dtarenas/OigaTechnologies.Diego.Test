using Core.Entities.User;
using Core.Entities.User.Exceptions;
using DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly OigaDbContext _context;

        public readonly DbSet<User> UserDbSet;

        public UserRepo(OigaDbContext context)
        {
            this._context = context;
            this.UserDbSet = this._context.Users;
        }

        public async ValueTask<User> AddAsync(User user)
        {
            await this.UserDbSet.AddAsync(user);
            return user;
        }

        public async ValueTask DeleteAsync(Guid userId)
        {
            var user = await this.GetByIdAsync(userId);
            if (user == null) throw new UserNotFoundException();
            this._context.Remove(user);
            await Task.CompletedTask;
        }

        public IQueryable<User> GetAll()
        {
            return this.UserDbSet.AsQueryable();
        }

        public async ValueTask<User?> GetByIdAsync(Guid userId)
        {
            return await this.UserDbSet.FindAsync(userId);
        }

        public User Update(User user)
        {
            this.UserDbSet.Attach(user);
            this._context.Entry(user).State = EntityState.Modified;
            return user;
        }

        public async ValueTask SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public async ValueTask<User?> GetByUsernameAsync(string username)
        {
            return await this.UserDbSet.FirstOrDefaultAsync(x => x.Username.ToUpper().Equals(username.ToUpper()));
        }
    }
}
