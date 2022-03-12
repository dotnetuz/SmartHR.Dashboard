using Microsoft.EntityFrameworkCore;
using SmartHR.Dashboard.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Data.Contexts
{
    public class SmartHRDbContext : DbContext
    {
        public SmartHRDbContext(DbContextOptions<SmartHRDbContext> options)
            :base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
