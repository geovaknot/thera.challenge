using System.Collections.Generic;
using Thera.Talent.Management.Domain.Entities;

namespace Thera.Talent.Management.Infrastructure.Context
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var users = new List<User>
            {
            new User{Name="Admin",Email="test@admin.com", Password="123Mudar", Profile=Profile.Administrators},
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}