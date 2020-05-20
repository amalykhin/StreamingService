﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SteamingService.Helpers;

namespace SteamingService.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200520203906_AddBroadcastUri")]
    partial class AddBroadcastUri
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SteamingService.Entities.Stream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BroadcastUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BroadcasterId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BroadcasterId");

                    b.ToTable("Streams");
                });

            modelBuilder.Entity("SteamingService.Entities.StreamViewer", b =>
                {
                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<int>("ViewerId")
                        .HasColumnType("int");

                    b.HasKey("StreamId", "ViewerId");

                    b.HasIndex("ViewerId");

                    b.ToTable("StreamViewer");
                });

            modelBuilder.Entity("SteamingService.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("HashSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("StreamerKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SteamingService.Entities.Stream", b =>
                {
                    b.HasOne("SteamingService.Models.User", "Broadcaster")
                        .WithMany()
                        .HasForeignKey("BroadcasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SteamingService.Entities.StreamViewer", b =>
                {
                    b.HasOne("SteamingService.Entities.Stream", "Stream")
                        .WithMany("Viewers")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SteamingService.Models.User", "Viewer")
                        .WithMany("StreamsWatching")
                        .HasForeignKey("ViewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
