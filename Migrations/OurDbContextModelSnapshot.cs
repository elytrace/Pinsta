﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pinsta.Models;

#nullable disable

namespace Pinsta.Migrations
{
    [DbContext(typeof(OurDbContext))]
    partial class OurDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Pinsta.Models.Entities.Comment", b =>
                {
                    b.Property<int>("commentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("imageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("commentId");

                    b.HasIndex("imageId");

                    b.HasIndex("userId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.Image", b =>
                {
                    b.Property<int>("imageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("caption")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("imagePath")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("uploadTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("imageId");

                    b.HasIndex("userId");

                    b.ToTable("images");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.Like", b =>
                {
                    b.Property<int>("likeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("imageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("likeId");

                    b.HasIndex("imageId");

                    b.HasIndex("userId");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.SearchRecent", b =>
                {
                    b.Property<int>("searchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("resultId")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeStamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("searchId");

                    b.HasIndex("userId");

                    b.ToTable("searchs");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("avatarPath")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("biography")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("dateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("displayedName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<byte>("gender")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("phone")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("userId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.Property<int>("followersuserId")
                        .HasColumnType("int");

                    b.Property<int>("followingsuserId")
                        .HasColumnType("int");

                    b.HasKey("followersuserId", "followingsuserId");

                    b.HasIndex("followingsuserId");

                    b.ToTable("follows", (string)null);
                });

            modelBuilder.Entity("Pinsta.Models.Entities.Comment", b =>
                {
                    b.HasOne("Pinsta.Models.Entities.Image", "image")
                        .WithMany("comments")
                        .HasForeignKey("imageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pinsta.Models.Entities.User", "user")
                        .WithMany("comments")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.Image", b =>
                {
                    b.HasOne("Pinsta.Models.Entities.User", "user")
                        .WithMany("images")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.Like", b =>
                {
                    b.HasOne("Pinsta.Models.Entities.Image", "image")
                        .WithMany("likes")
                        .HasForeignKey("imageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pinsta.Models.Entities.User", "user")
                        .WithMany("likes")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("image");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.SearchRecent", b =>
                {
                    b.HasOne("Pinsta.Models.Entities.User", "user")
                        .WithMany("searchs")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("UserUser", b =>
                {
                    b.HasOne("Pinsta.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("followersuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pinsta.Models.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("followingsuserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Pinsta.Models.Entities.Image", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("likes");
                });

            modelBuilder.Entity("Pinsta.Models.Entities.User", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("images");

                    b.Navigation("likes");

                    b.Navigation("searchs");
                });
#pragma warning restore 612, 618
        }
    }
}
