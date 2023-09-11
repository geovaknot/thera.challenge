using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Thera.Talent.Management.Domain.Entities;

namespace Thera.Talent.Management.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultDatabase")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.Talent> Talents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}