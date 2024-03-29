﻿// <auto-generated />
using System;
using GoldenSealWebApi.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240112075655_RemoveRankingFieldFromGroundSensors")]
    partial class RemoveRankingFieldFromGroundSensors
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GoldenSealWebApi.Database.DockStation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts");

                    b.Property<string>("GeoJSON")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("geojson");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DockStations");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.Drone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts");

                    b.Property<int>("DockStationId")
                        .HasColumnType("int(11)")
                        .HasColumnName("dock_station_id");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("DockStationId");

                    b.ToTable("Drones");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DroneDetectedWasteLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("BBPointGeoJSON")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("bb_point_geojson");

                    b.Property<string>("BBPolygonGeoJSON")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("bb_polygon_geojson");

                    b.Property<int>("CMLOUploadId")
                        .HasColumnType("int(11)")
                        .HasColumnName("cmlo_upload_id");

                    b.Property<float?>("ConfidenceLevel")
                        .HasColumnType("float")
                        .HasColumnName("confidence_level");

                    b.Property<int>("DroneId")
                        .HasColumnType("int(11)")
                        .HasColumnName("drone_id");

                    b.Property<string>("GeoreferencedImage")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("georeferenced_image");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("image");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int(11)")
                        .HasColumnName("region_id");

                    b.Property<int>("Size")
                        .HasColumnType("int")
                        .HasColumnName("size");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("ts");

                    b.Property<int>("Type")
                        .HasColumnType("int")
                        .HasColumnName("type");

                    b.Property<float?>("UploadConfidenceLevel")
                        .HasColumnType("float")
                        .HasColumnName("upload_confidence_level");

                    b.Property<string>("WMSService")
                        .HasColumnType("varchar(500)")
                        .HasColumnName("wms_service");

                    b.HasKey("Id");

                    b.HasIndex("DroneId");

                    b.HasIndex("RegionId");

                    b.ToTable("DroneDetectedWasteLogs");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DronePreflightConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<long?>("Altitude")
                        .HasColumnType("bigint")
                        .HasColumnName("altitude");

                    b.Property<int>("DroneId")
                        .HasColumnType("int(11)")
                        .HasColumnName("drone_id");

                    b.Property<int?>("PilotId")
                        .HasColumnType("int(11)")
                        .HasColumnName("pilot_id");

                    b.Property<int>("RegionId")
                        .HasColumnType("int(11)")
                        .HasColumnName("region_id");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int(11)")
                        .HasColumnName("route_id");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("ts");

                    b.HasKey("Id");

                    b.HasIndex("DroneId")
                        .IsUnique();

                    b.HasIndex("PilotId");

                    b.HasIndex("RegionId");

                    b.HasIndex("RouteId");

                    b.ToTable("DronePreflightConfig");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DroneState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<long?>("Altitude")
                        .HasColumnType("bigint")
                        .HasColumnName("altitude");

                    b.Property<float?>("Battery")
                        .HasColumnType("float")
                        .HasColumnName("battery");

                    b.Property<int>("DroneId")
                        .HasColumnType("int(11)")
                        .HasColumnName("drone_id");

                    b.Property<long?>("Latitude")
                        .HasColumnType("bigint")
                        .HasColumnName("latitude");

                    b.Property<long?>("Longitude")
                        .HasColumnType("bigint")
                        .HasColumnName("longitude");

                    b.Property<int?>("PilotId")
                        .HasColumnType("int(11)")
                        .HasColumnName("pilot_id");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int(11)")
                        .HasColumnName("region_id");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int(11)")
                        .HasColumnName("route_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("ts");

                    b.Property<float?>("VelocityX")
                        .HasColumnType("float")
                        .HasColumnName("velocity_x");

                    b.Property<float?>("VelocityY")
                        .HasColumnType("float")
                        .HasColumnName("velocity_y");

                    b.Property<float?>("VelocityZ")
                        .HasColumnType("float")
                        .HasColumnName("velocity_z");

                    b.HasKey("Id");

                    b.HasIndex("DroneId")
                        .IsUnique();

                    b.HasIndex("PilotId");

                    b.HasIndex("RegionId");

                    b.HasIndex("RouteId");

                    b.ToTable("DroneStates");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DroneStateLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<long?>("Altitude")
                        .HasColumnType("bigint")
                        .HasColumnName("altitude");

                    b.Property<float?>("Battery")
                        .HasColumnType("float")
                        .HasColumnName("battery");

                    b.Property<int>("DroneId")
                        .HasColumnType("int(11)")
                        .HasColumnName("drone_id");

                    b.Property<long?>("Latitude")
                        .HasColumnType("bigint")
                        .HasColumnName("latitude");

                    b.Property<long?>("Longitude")
                        .HasColumnType("bigint")
                        .HasColumnName("longitude");

                    b.Property<int?>("PilotId")
                        .HasColumnType("int(11)")
                        .HasColumnName("pilot_id");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int(11)")
                        .HasColumnName("region_id");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int(11)")
                        .HasColumnName("route_id");

                    b.Property<int>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("ts");

                    b.Property<float?>("VelocityX")
                        .HasColumnType("float")
                        .HasColumnName("velocity_x");

                    b.Property<float?>("VelocityY")
                        .HasColumnType("float")
                        .HasColumnName("velocity_y");

                    b.Property<float?>("VelocityZ")
                        .HasColumnType("float")
                        .HasColumnName("velocity_z");

                    b.HasKey("Id");

                    b.HasIndex("DroneId");

                    b.HasIndex("PilotId");

                    b.HasIndex("RegionId");

                    b.HasIndex("RouteId");

                    b.ToTable("DroneStateLogs");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.GroundWasteSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("RefId")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("ref_id");

                    b.Property<int>("RegionId")
                        .HasColumnType("int(11)")
                        .HasColumnName("region_id");

                    b.HasKey("Id");

                    b.HasIndex("RefId")
                        .IsUnique();

                    b.HasIndex("RegionId");

                    b.ToTable("GroundWasteSensors");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.GroundWasteSensorState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("GroundWasteSensorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ground_waste_sensor_id");

                    b.Property<float>("MassKg")
                        .HasColumnType("float")
                        .HasColumnName("mass_kg");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("ts");

                    b.HasKey("Id");

                    b.HasIndex("GroundWasteSensorId");

                    b.ToTable("GroundWasteSensorStates");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.GroundWasteSensorStateLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("GroundWasteSensorId")
                        .HasColumnType("int(11)")
                        .HasColumnName("ground_waste_sensor_id");

                    b.Property<float>("MassKg")
                        .HasColumnType("float")
                        .HasColumnName("mass_kg");

                    b.Property<DateTime>("Ts")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("ts");

                    b.HasKey("Id");

                    b.HasIndex("GroundWasteSensorId");

                    b.ToTable("GroundWasteSensorStateLogs");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<float>("Area")
                        .HasColumnType("float")
                        .HasColumnName("area");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts");

                    b.Property<string>("GeoJSON")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("geojson");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts");

                    b.Property<string>("GeoJSON")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("geojson");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int?>("RegionId")
                        .HasColumnType("int(11)")
                        .HasColumnName("region_id");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RegionId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedTs")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasColumnName("created_ts");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<int>("Role")
                        .HasColumnType("int(3)")
                        .HasColumnName("role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.Property<string>("XApiKey")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("x_api_key");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.Drone", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.DockStation", "DockStation")
                        .WithMany()
                        .HasForeignKey("DockStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DockStation");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DroneDetectedWasteLog", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.Drone", "Drone")
                        .WithMany()
                        .HasForeignKey("DroneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenSealWebApi.Database.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.Navigation("Drone");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DronePreflightConfig", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.Drone", "Drone")
                        .WithMany()
                        .HasForeignKey("DroneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenSealWebApi.Database.User", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");

                    b.HasOne("GoldenSealWebApi.Database.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenSealWebApi.Database.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");

                    b.Navigation("Drone");

                    b.Navigation("Pilot");

                    b.Navigation("Region");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DroneState", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.Drone", "Drone")
                        .WithMany()
                        .HasForeignKey("DroneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenSealWebApi.Database.User", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");

                    b.HasOne("GoldenSealWebApi.Database.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("GoldenSealWebApi.Database.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");

                    b.Navigation("Drone");

                    b.Navigation("Pilot");

                    b.Navigation("Region");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.DroneStateLog", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.Drone", "Drone")
                        .WithMany()
                        .HasForeignKey("DroneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldenSealWebApi.Database.User", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId");

                    b.HasOne("GoldenSealWebApi.Database.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.HasOne("GoldenSealWebApi.Database.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId");

                    b.Navigation("Drone");

                    b.Navigation("Pilot");

                    b.Navigation("Region");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.GroundWasteSensor", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.GroundWasteSensorState", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.GroundWasteSensor", "GroundWasteSensor")
                        .WithMany()
                        .HasForeignKey("GroundWasteSensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroundWasteSensor");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.GroundWasteSensorStateLog", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.GroundWasteSensor", "GroundWasteSensor")
                        .WithMany()
                        .HasForeignKey("GroundWasteSensorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GroundWasteSensor");
                });

            modelBuilder.Entity("GoldenSealWebApi.Database.Route", b =>
                {
                    b.HasOne("GoldenSealWebApi.Database.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId");

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
