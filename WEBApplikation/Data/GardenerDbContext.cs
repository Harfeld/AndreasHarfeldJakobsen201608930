using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WEBApplikation.Models;

namespace WEBApplikation.Data.Migrations
{
    public class GardenerDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        public GardenerDbContext()
        {
           
        }

        public GardenerDbContext(DbContextOptions<GardenerDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=WebGardenerDatabase;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tree>()
                .HasOne(t => t.Location)
                .WithMany(l => l.Trees)
                .HasForeignKey(t => t.LocationId);

            modelBuilder.Entity<Sensor>()
                .HasOne(s => s.Location)
                .WithMany(l => l.Sensors)
                .HasForeignKey(s => s.LocationId);

            modelBuilder.Entity<Location>().HasData(
                new Location
                {
                    LocationId = 1,
                    Name = "Ringgaden",
                    Road = "Ringgaden",
                    RoadNumber = "22",
                    PostalCode = 8210,
                    City = "Århus"
                },
                new Location
                {
                    LocationId = 2,
                    Name = "Randersvej",
                    Road = "Randersvej",
                    RoadNumber = "43",
                    PostalCode = 8000,
                    City = "Århus"
                }
            );
            modelBuilder.Entity<Tree>().HasData(
                new Tree
                {
                    TreeId = 1,
                    LocationId = 1, 
                    Amount = 5,
                    Species = "Bøg"
                },
                new Tree{
                    TreeId = 2,
                    LocationId = 1,
                    Amount = 2,
                    Species = "Birk"
                },
                new Tree
                {
                    TreeId = 3,
                    LocationId = 2,
                    Amount = 15,
                    Species = "Eg"
                },
                new Tree
                {
                    TreeId = 4,
                    LocationId = 2,
                    Amount = 2,
                    Species = "Ask"
                }
            );
            modelBuilder.Entity<Sensor>().HasData(
                new Sensor
                {
                    LocationId = 1,
                    SensorId = "0000000000000001",
                    Species = "Bøg",
                    Latitude = 56.1629,
                    Lontitude = 10.2039
                },
                new Sensor
                {
                    LocationId = 1,
                    SensorId = "0000000000000002",
                    Species = "Bøg",
                    Latitude = 56.1624,
                    Lontitude = 10.2031
                },
                new Sensor
                {
                    LocationId = 1,
                    SensorId = "0000000000000003",
                    Species = "Birk",
                    Latitude = 56.1628,
                    Lontitude = 10.2032
                },
                new Sensor
                {
                    LocationId = 2,
                    SensorId = "0000000000000004",
                    Species = "Eg",
                    Latitude = 56.1500,
                    Lontitude = 10.2000
                },
                new Sensor
                {
                    LocationId = 2,
                    SensorId = "0000000000000005",
                    Species = "Ask",
                    Latitude = 56.1502,
                    Lontitude = 10.2065
                },
                new Sensor
                {
                    LocationId = 2,
                    SensorId = "0000000000000006",
                    Species = "Eg",
                    Latitude = 56.1522,
                    Lontitude = 10.2045
                },
                new Sensor
                {
                    LocationId = 2,
                    SensorId = "0000000000000007",
                    Species = "Eg",
                    Latitude = 56.1501,
                    Lontitude = 10.2400
                },
                new Sensor
                {
                    LocationId = 2,
                    SensorId = "0000000000000008",
                    Species = "Ask",
                    Latitude = 56.1530,
                    Lontitude = 10.2020
                }
            );
        }
    }
}
