﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Threax.Home.Database;

namespace Threax.Home.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Threax.AspNetCore.UserBuilder.Entities.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(450);

                    b.HasKey("RoleId");

                    b.ToTable("spc.auth.Roles");
                });

            modelBuilder.Entity("Threax.AspNetCore.UserBuilder.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(450);

                    b.HasKey("UserId");

                    b.ToTable("spc.auth.Users");
                });

            modelBuilder.Entity("Threax.AspNetCore.UserBuilder.Entities.UserToRole", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("spc.auth.UsersToRoles");
                });

            modelBuilder.Entity("Threax.Home.Database.SwitchEntity", b =>
                {
                    b.Property<Guid>("SwitchId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bridge")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int?>("Brightness");

                    b.Property<DateTime>("Created");

                    b.Property<string>("HexColor")
                        .HasMaxLength(450);

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Subsystem")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Value")
                        .HasMaxLength(450);

                    b.HasKey("SwitchId");

                    b.ToTable("Switches");
                });

            modelBuilder.Entity("Threax.AspNetCore.UserBuilder.Entities.UserToRole", b =>
                {
                    b.HasOne("Threax.AspNetCore.UserBuilder.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Threax.AspNetCore.UserBuilder.Entities.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
