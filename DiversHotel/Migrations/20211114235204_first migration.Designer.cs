// <auto-generated />
using System;
using DiversHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DiversHotel.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20211114235204_first migration")]
    partial class firstmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DiversHotel.Models.MealPlans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("mealPlans")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ratePerPerson_high_season")
                        .HasColumnType("int");

                    b.Property<int>("ratePerPerson_low_season")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MealPlans");
                });

            modelBuilder.Entity("DiversHotel.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("checkin_date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("checkout_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("meal_plan_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("no_adult")
                        .HasColumnType("int");

                    b.Property<int>("no_children")
                        .HasColumnType("int");

                    b.Property<int>("room_type_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("DiversHotel.Models.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ratePerPreson")
                        .HasColumnType("int");

                    b.Property<string>("roomType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });
#pragma warning restore 612, 618
        }
    }
}
