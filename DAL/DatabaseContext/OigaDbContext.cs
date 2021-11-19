using Core.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.DatabaseContext
{
    public class OigaDbContext : DbContext
    {
        public OigaDbContext(DbContextOptions<OigaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
