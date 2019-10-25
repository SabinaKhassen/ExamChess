namespace DataLayer.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        //static Model1()
        //{
        //    Database.SetInitializer<Model1>(new Initializer());
        //}

        public Model1()
            : base("name=Model1")
        {
        }

        //public virtual DbSet<BoardColors> BoardColors { get; set; }
        public virtual DbSet<ChessTypes> ChessTypes { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        //public virtual DbSet<Checkers> Checkers { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BoardColors>()
            //    .HasMany(e => e.Games)
            //    .WithRequired(e => e.BoardColors)
            //    .HasForeignKey(e => e.BoardColorId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cities>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Cities)
                .HasForeignKey(e => e.CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Roles)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.PlayerOne)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Games1)
                .WithRequired(e => e.Users1)
                .HasForeignKey(e => e.PlayerTwo)
                .WillCascadeOnDelete(false);
        }
    }

    public class Initializer : DropCreateDatabaseIfModelChanges<Model1>
    {
        //protected override void Seed(Model1 db)
        //{
        //    db.Roles.AddOrUpdate(new Roles { Status = "Admin" });

        //    db.Countries.AddOrUpdate(new Countries { Name = "Kazakhstan" });
        //    db.Cities.AddOrUpdate(new Cities { Name = "Karaganda" });

        //    db.Users.AddOrUpdate(new Users { FIO = "User1", CityId = 1, Email = "user1@mail.ru", Nick = "User1", Password = "000", RoleId = 1 });
        //    db.Users.AddOrUpdate(new Users { FIO = "User2", CityId = 1, Email = "user2@mail.ru", Nick = "User2", Password = "000", RoleId = 1 });

        //    db.Colors.AddOrUpdate(new Colors { Color = "black" });
        //    db.Colors.AddOrUpdate(new Colors { Color = "white" });
        //    db.Colors.AddOrUpdate(new Colors { Color = "#666666" });

        //    db.ChessTypes.AddOrUpdate(new ChessTypes { Name = "Russian" });
        //    db.ChessTypes.AddOrUpdate(new ChessTypes { Name = "100x100" });
        //    db.ChessTypes.AddOrUpdate(new ChessTypes { Name = "Plow" });

        //    db.BoardColors.AddOrUpdate(new BoardColors { ColorOne = 1, ColorTwo = 3 });

        //    db.SaveChanges();
        //}
    }
}
