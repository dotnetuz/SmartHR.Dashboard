using Microsoft.EntityFrameworkCore;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Domain.Entities.Users;

namespace SmartHR.Dashboard.Data.Contexts
{
    public class SmartHRDbContext : DbContext
    {
        public SmartHRDbContext(DbContextOptions<SmartHRDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAuth> UserAuths { get; set; }
        public virtual DbSet<Interview> Interviews { get; set; }
    }
}
