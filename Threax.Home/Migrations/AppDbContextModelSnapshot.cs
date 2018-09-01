﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799");

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

            modelBuilder.Entity("Threax.Home.Database.ButtonEntity", b =>
                {
                    b.Property<Guid>("ButtonId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Label");

                    b.Property<DateTime>("Modified");

                    b.HasKey("ButtonId");

                    b.ToTable("Buttons");
                });

            modelBuilder.Entity("Threax.Home.Database.ButtonStateEntity", b =>
                {
                    b.Property<Guid>("ButtonStateId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ButtonId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Label");

                    b.Property<DateTime>("Modified");

                    b.HasKey("ButtonStateId");

                    b.HasIndex("ButtonId");

                    b.ToTable("ButtonStates");
                });

            modelBuilder.Entity("Threax.Home.Database.SensorEntity", b =>
                {
                    b.Property<Guid>("SensorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bridge")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<DateTime>("Created");

                    b.Property<int?>("HumidityUnits");

                    b.Property<double?>("HumidityValue");

                    b.Property<string>("Id")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int?>("LightUnits");

                    b.Property<double?>("LightValue");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("Subsystem")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int?>("TempUnits");

                    b.Property<double?>("TempValue");

                    b.Property<int?>("UvUnits");

                    b.Property<double?>("UvValue");

                    b.HasKey("SensorId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("Threax.Home.Database.SwitchEntity", b =>
                {
                    b.Property<Guid>("SwitchId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bridge")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<byte?>("Brightness");

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

                    b.HasIndex("Bridge", "Subsystem", "Id")
                        .IsUnique();

                    b.ToTable("Switches");
                });

            modelBuilder.Entity("Threax.Home.Database.SwitchSettingEntity", b =>
                {
                    b.Property<Guid>("SwitchSettingId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Brightness");

                    b.Property<Guid>("ButtonStateId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("HexColor")
                        .HasMaxLength(450);

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("SwitchId");

                    b.Property<string>("Value");

                    b.HasKey("SwitchSettingId");

                    b.HasIndex("ButtonStateId");

                    b.ToTable("SwitchSettings");
                });

            modelBuilder.Entity("Threax.Home.Database.ThermostatEntity", b =>
                {
                    b.Property<Guid>("ThermostatId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AvailableModes");

                    b.Property<int>("Away");

                    b.Property<string>("Bridge");

                    b.Property<int>("CoolTemp");

                    b.Property<int>("CoolTempMax");

                    b.Property<int>("CoolTempMin");

                    b.Property<DateTime>("Created");

                    b.Property<int>("Fan");

                    b.Property<int>("FanState");

                    b.Property<int>("ForceUnocc");

                    b.Property<int>("HeatTemp");

                    b.Property<int>("HeatTempMax");

                    b.Property<int>("HeatTempMin");

                    b.Property<int>("Holidy");

                    b.Property<int>("Humidity");

                    b.Property<string>("Id");

                    b.Property<int>("Mode");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<int>("Override");

                    b.Property<int>("OverrideTime");

                    b.Property<int>("Schedule");

                    b.Property<int>("SchedulePart");

                    b.Property<int>("SetPointDelta");

                    b.Property<int>("SpaceTemp");

                    b.Property<int>("State");

                    b.Property<string>("Subsystem");

                    b.Property<int>("TempUnits");

                    b.HasKey("ThermostatId");

                    b.ToTable("Thermostats");
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

            modelBuilder.Entity("Threax.Home.Database.ButtonStateEntity", b =>
                {
                    b.HasOne("Threax.Home.Database.ButtonEntity", "Button")
                        .WithMany("ButtonStates")
                        .HasForeignKey("ButtonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Threax.Home.Database.SwitchSettingEntity", b =>
                {
                    b.HasOne("Threax.Home.Database.ButtonStateEntity", "ButtonState")
                        .WithMany("SwitchSettings")
                        .HasForeignKey("ButtonStateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
