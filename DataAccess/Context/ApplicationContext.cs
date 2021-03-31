using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataAccess.Entities;

namespace DataAccess.Context
{
    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<ParkingPlace> ParkingPlaces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=Parking.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParkingPlace>(entity =>
            {
                entity.HasOne(place => place.Owner)
                      .WithMany(person => person.Places)
                      .HasForeignKey(place => place.OwnerId);

                entity.Property(parking => parking.Number).IsRequired();
                entity.HasIndex(parking => parking.Number).IsUnique();

                entity.Property(person => person.Flor).IsRequired();
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(person => person.PhoneNumber).IsRequired();
                entity.HasIndex(person => person.PhoneNumber).IsUnique();

                entity.Property(person => person.Name).IsRequired();
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
