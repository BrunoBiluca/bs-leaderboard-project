﻿// <auto-generated />
using System;
using GTSharp.Domain.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GTSharp.Domain.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200711203344_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2");

            modelBuilder.Entity("GTSharp.Domain.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("GTSharp.Domain.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Avatar")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2);

                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("GTSharp.Domain.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Stage")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Time")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<int?>("Value")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("GTSharp.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Avatar")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2);

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(64);

                    b.Property<string>("Picture")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GTSharp.Domain.Entities.Player", b =>
                {
                    b.HasOne("GTSharp.Domain.Entities.Game", null)
                        .WithMany("Players")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GTSharp.Domain.Entities.User", null)
                        .WithMany("Players")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GTSharp.Domain.Entities.Score", b =>
                {
                    b.HasOne("GTSharp.Domain.Entities.Player", null)
                        .WithMany("Scores")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
