﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("WebApplication1.Models.BusinessService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BusinessServices");
                });

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DurationInSeconds")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("RiskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RiskId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("WebApplication1.Models.EventsLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsExternalFactor")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventsLogs");
                });

            modelBuilder.Entity("WebApplication1.Models.Incident", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("RiskId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RiskId");

                    b.ToTable("Incidents");
                });

            modelBuilder.Entity("WebApplication1.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusinessServiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BusinessServiceId");

                    b.ToTable("Operations");
                });

            modelBuilder.Entity("WebApplication1.Models.Risk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("OperationId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Prob")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WantedStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.ToTable("Risks");
                });

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.HasOne("WebApplication1.Models.Risk", null)
                        .WithMany("Events")
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.EventsLog", b =>
                {
                    b.HasOne("WebApplication1.Models.Event", null)
                        .WithMany("EventsLogs")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("WebApplication1.Models.Incident", b =>
                {
                    b.HasOne("WebApplication1.Models.Risk", null)
                        .WithMany("Incidents")
                        .HasForeignKey("RiskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Operation", b =>
                {
                    b.HasOne("WebApplication1.Models.BusinessService", null)
                        .WithMany("Operations")
                        .HasForeignKey("BusinessServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.Risk", b =>
                {
                    b.HasOne("WebApplication1.Models.Operation", null)
                        .WithMany("Risks")
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Models.BusinessService", b =>
                {
                    b.Navigation("Operations");
                });

            modelBuilder.Entity("WebApplication1.Models.Event", b =>
                {
                    b.Navigation("EventsLogs");
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
