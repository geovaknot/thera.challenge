namespace Thera.Talent.Management.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Thera.Talent.Management.Domain.Entities;
    using Thera.Talent.Management.Infrastructure.Context;

    internal sealed class Configuration : DbMigrationsConfiguration<Thera.Talent.Management.Infrastructure.Context.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

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
