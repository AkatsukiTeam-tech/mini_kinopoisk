using Microsoft.EntityFrameworkCore;
using mini_kp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mini_kp.Data
{
    public class KPContext : DbContext
    {
        public KPContext(DbContextOptions<KPContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=kp_test;Trusted_Connection=True");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Films_Actors>().HasKey(sc => new { sc.ActorId, sc.FilmId });
            modelBuilder.Entity<Films_Actors>()
                .HasOne<Film>(sc => sc.Film)
                .WithMany(s => s.Films_Actors)
                .HasForeignKey(sc => sc.FilmId);

            modelBuilder.Entity<Films_Actors>()
                .HasOne<Actor>(sc => sc.Actor)
                .WithMany(s => s.Films_Actors)
                .HasForeignKey(sc => sc.ActorId);


            modelBuilder.Entity<Films_Genres>().HasKey(sc => new { sc.GenreId, sc.FilmsId });
            modelBuilder.Entity<Films_Genres>()
                .HasOne<Film>(sc => sc.Film)
                .WithMany(s => s.Films_Genres)
                .HasForeignKey(sc => sc.FilmsId);

            modelBuilder.Entity<Films_Genres>()
                .HasOne<Genre>(sc => sc.Genre)
                .WithMany(s => s.Films_Genres)
                .HasForeignKey(sc => sc.GenreId);


            modelBuilder.Entity<Films_Countries>().HasKey(sc => new { sc.CountryId, sc.FilmId });
            modelBuilder.Entity<Films_Countries>()
                .HasOne<Film>(sc => sc.Film)
                .WithMany(s => s.Films_Countries)
                .HasForeignKey(sc => sc.FilmId);

            modelBuilder.Entity<Films_Countries>()
                .HasOne<Country>(sc => sc.Country)
                .WithMany(s => s.Films_Countries)
                .HasForeignKey(sc => sc.CountryId);


            modelBuilder.Entity<Films_Users>().HasKey(sc => new { sc.UserId, sc.FilmId });
            modelBuilder.Entity<Films_Users>()
                .HasOne<Film>(sc => sc.Film)
                .WithMany(s => s.Films_Users)
                .HasForeignKey(sc => sc.FilmId);

            modelBuilder.Entity<Films_Users>()
                .HasOne<User>(sc => sc.User)
                .WithMany(s => s.Films_Users)
                .HasForeignKey(sc => sc.UserId);
        }*/

        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        //public DbSet<Films_Actors> Films_Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        //public DbSet<Films_Genres> Films_Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        //public DbSet<Films_Countries> Films_Countries { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<Films_Users> Films_Users { get; set; }
    }
}
