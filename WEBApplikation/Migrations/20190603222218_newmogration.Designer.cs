﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEBApplikation.Data.Migrations;

namespace WEBApplikation.Migrations
{
    [DbContext(typeof(GardenerDbContext))]
    [Migration("20190603222218_newmogration")]
    partial class newmogration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEBApplikation.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PostalCode");

                    b.Property<string>("Road")
                        .IsRequired();

                    b.Property<string>("RoadNumber")
                        .IsRequired();

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 1,
                            City = "Århus",
                            Name = "Ringgaden",
                            PostalCode = 8210,
                            Road = "Ringgaden",
                            RoadNumber = "22"
                        },
                        new
                        {
                            LocationId = 2,
                            City = "Århus",
                            Name = "Randersvej",
                            PostalCode = 8000,
                            Road = "Randersvej",
                            RoadNumber = "43"
                        });
                });

            modelBuilder.Entity("WEBApplikation.Models.Sensor", b =>
                {
                    b.Property<string>("SensorId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(16);

                    b.Property<double>("Latitude");

                    b.Property<int>("LocationId");

                    b.Property<double>("Lontitude");

                    b.Property<string>("Species")
                        .IsRequired();

                    b.HasKey("SensorId");

                    b.HasIndex("LocationId");

                    b.ToTable("Sensors");

                    b.HasData(
                        new
                        {
                            SensorId = "0000000000000001",
                            Latitude = 56.1629,
                            LocationId = 1,
                            Lontitude = 10.203900000000001,
                            Species = "Bøg"
                        },
                        new
                        {
                            SensorId = "0000000000000002",
                            Latitude = 56.162399999999998,
                            LocationId = 1,
                            Lontitude = 10.203099999999999,
                            Species = "Bøg"
                        },
                        new
                        {
                            SensorId = "0000000000000003",
                            Latitude = 56.162799999999997,
                            LocationId = 1,
                            Lontitude = 10.203200000000001,
                            Species = "Birk"
                        },
                        new
                        {
                            SensorId = "0000000000000004",
                            Latitude = 56.149999999999999,
                            LocationId = 2,
                            Lontitude = 10.199999999999999,
                            Species = "Eg"
                        },
                        new
                        {
                            SensorId = "0000000000000005",
                            Latitude = 56.150199999999998,
                            LocationId = 2,
                            Lontitude = 10.2065,
                            Species = "Ask"
                        },
                        new
                        {
                            SensorId = "0000000000000006",
                            Latitude = 56.152200000000001,
                            LocationId = 2,
                            Lontitude = 10.204499999999999,
                            Species = "Eg"
                        },
                        new
                        {
                            SensorId = "0000000000000007",
                            Latitude = 56.150100000000002,
                            LocationId = 2,
                            Lontitude = 10.24,
                            Species = "Eg"
                        },
                        new
                        {
                            SensorId = "0000000000000008",
                            Latitude = 56.152999999999999,
                            LocationId = 2,
                            Lontitude = 10.202,
                            Species = "Ask"
                        });
                });

            modelBuilder.Entity("WEBApplikation.Models.Tree", b =>
                {
                    b.Property<int>("TreeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int>("LocationId");

                    b.Property<string>("Species")
                        .IsRequired();

                    b.HasKey("TreeId");

                    b.HasIndex("LocationId");

                    b.ToTable("Trees");

                    b.HasData(
                        new
                        {
                            TreeId = 1,
                            Amount = 5,
                            LocationId = 1,
                            Species = "Bøg"
                        },
                        new
                        {
                            TreeId = 2,
                            Amount = 2,
                            LocationId = 1,
                            Species = "Birk"
                        },
                        new
                        {
                            TreeId = 3,
                            Amount = 15,
                            LocationId = 2,
                            Species = "Eg"
                        },
                        new
                        {
                            TreeId = 4,
                            Amount = 2,
                            LocationId = 2,
                            Species = "Ask"
                        });
                });

            modelBuilder.Entity("WEBApplikation.Models.Sensor", b =>
                {
                    b.HasOne("WEBApplikation.Models.Location", "Location")
                        .WithMany("Sensors")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WEBApplikation.Models.Tree", b =>
                {
                    b.HasOne("WEBApplikation.Models.Location", "Location")
                        .WithMany("Trees")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
