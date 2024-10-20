﻿// <auto-generated />
using System;
using HorseRace.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HorseRace.Migrations
{
    [DbContext(typeof(HorseRaceManagementContext))]
    partial class HorseRaceManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("HorseRace.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NumRaces")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("HorseRace.Models.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RaceId");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("HorseRace.Models.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Races");
                });

            modelBuilder.Entity("HorseRace.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HorseRace.Models.Horse", b =>
                {
                    b.HasOne("HorseRace.Models.Race", null)
                        .WithMany("Horses")
                        .HasForeignKey("RaceId");
                });

            modelBuilder.Entity("HorseRace.Models.Race", b =>
                {
                    b.HasOne("HorseRace.Models.Event", null)
                        .WithMany("Races")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HorseRace.Models.Event", b =>
                {
                    b.Navigation("Races");
                });

            modelBuilder.Entity("HorseRace.Models.Race", b =>
                {
                    b.Navigation("Horses");
                });
#pragma warning restore 612, 618
        }
    }
}
