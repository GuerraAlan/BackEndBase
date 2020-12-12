using BackendBase.DataAccess.Mappings;
using BackEndBase.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendBase.DataAccess.Context
{
    public class BaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BackendBase");
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}