namespace ClientWPF.Migrations
{
    using ModelsLibrary.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ClientWPF.Repositories.Implementation.Manager.ModelsManager>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClientWPF.Repositories.Implementation.Manager.ModelsManager context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Users.AddOrUpdate(
            //new User { Name = "John", Password = "password1", RoleId = 1, RegistrationDate = DateTime.Now },
           //new User { Name = "Jane", Password = "password2", RoleId = 1, RegistrationDate = DateTime.Now }
           //);
           //context.Roles.AddOrUpdate(
                //new Role { Id = 1, Name = "User" }
               // );

            //context.SaveChanges();

        }
    }
}
