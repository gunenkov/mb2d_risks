﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20211025174439_DB")]
    partial class DB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.BusinessService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusinessServices");
                });

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DurationInSeconds")
                        .HasColumnType("int");

                    b.Property<int?>("IncidentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RiskId")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.HasIndex("RiskId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WebApplication1.Models.EventsLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Finish")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsExternalFactor")
                        .HasColumnType("bit");

                    b.Property<int>("RiskId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId")
                        .IsUnique();

                    b.ToTable("EventsLogs");
                });

            modelBuilder.Entity("WebApplication1.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ccorresponds")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Result")
                        .HasColumnType("int");

                    b.Property<int>("RiskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RiskId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("WebApplication1.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessServiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BusinessServiceId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("WebApplication1.Models.Risk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("int");

                    b.Property<int>("Damage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OperationId")
                        .HasColumnType("int");

                    b.Property<int>("Prob")
                        .HasColumnType("int");

                    b.Property<int>("WantedStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Risks");
                });

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.HasOne("WebApplication1.Models.Incident", null)
                        .WithMany("Events")
                        .HasForeignKey("IncidentId");

                    b.HasOne("WebApplication1.Models.Risk", null)
                        .WithMany("Events")
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.EventsLog", b =>
                {
                    b.HasOne("WebApplication1.Models.Event", null)
                        .WithOne("EventsLog")
                        .HasForeignKey("WebApplication1.Models.EventsLog", "EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Incident", b =>
                {
                    b.HasOne("WebApplication1.Models.Risk", "Risk")
                        .WithMany("Incidents")
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Risk");
                });

            modelBuilder.Entity("WebApplication1.Models.Operation", b =>
                {
                    b.HasOne("WebApplication1.Models.BusinessService", "BusinessService")
                        .WithMany("Operations")
                        .HasForeignKey("BusinessServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessService");
                });

            modelBuilder.Entity("WebApplication1.Models.Risk", b =>
                {
                    b.HasOne("WebApplication1.Models.Operation", "Operation")
                        .WithMany("Risks")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Operation");
                });

            modelBuilder.Entity("WebApplication1.Models.BusinessService", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.Navigation("EventsLog");
                });

            modelBuilder.Entity("WebApplication1.Models.Incident", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("WebApplication1.Models.Operation", b =>
                {
                    b.Navigation("Risks");
                });

            modelBuilder.Entity("WebApplication1.Models.Risk", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Incidents");
                });
#pragma warning restore 612, 618
        }
    }
}
