using BackEndBase.DataAccess.Mappings;
using BackEndBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndBase.DataAccess.Context
{
    public class BaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BackEndBase");
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}