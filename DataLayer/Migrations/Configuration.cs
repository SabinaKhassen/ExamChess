namespace DataLayer.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataLayer.Entities.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataLayer.Entities.Model1 db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            db.Roles.AddOrUpdate(new Roles { Status = "Admin" });
            db.Roles.AddOrUpdate(new Roles { Status = "User" });

            db.Countries.AddOrUpdate(new Countries { Name = "Kazakhstan" });
            db.Cities.AddOrUpdate(new Cities { Name = "Karaganda", CountryId = 1 });
            db.Cities.AddOrUpdate(new Cities { Name = "Almaty", CountryId = 1 });

            db.SaveChanges();

            db.Users.AddOrUpdate(new Users { FIO = "User1", CityId = 1, Email = "user1@mail.ru", Nick = "User1", Password = "000", RoleId = 1 });
            db.Users.AddOrUpdate(new Users { FIO = "User2", CityId = 2, Email = "user2@mail.ru", Nick = "User2", Password = "000", RoleId = 2 });

            db.Colors.AddOrUpdate(new Colors { Color = "black" });
            db.Colors.AddOrUpdate(new Colors { Color = "white" });

            db.SaveChanges();

            db.ChessTypes.AddOrUpdate(new ChessTypes { Name = "Russian" });
            db.ChessTypes.AddOrUpdate(new ChessTypes { Name = "100x100" });
            db.ChessTypes.AddOrUpdate(new ChessTypes { Name = "Plow" });

            db.SaveChanges();
        }
    }
}
