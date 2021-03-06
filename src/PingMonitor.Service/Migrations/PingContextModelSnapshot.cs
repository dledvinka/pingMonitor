﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PingMonitor.Service;

namespace PingMonitor.Service.Migrations
{
    [DbContext(typeof(PingContext))]
    partial class PingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("PingMonitor.Service.PingBatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IntervalBetweenPingsMs");

                    b.Property<string>("MachineName");

                    b.Property<int>("PingTimeoutMs");

                    b.Property<string>("TargetUrl");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("Id");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("PingMonitor.Service.PingResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PingBatchId");

                    b.Property<long>("RoundtripTime");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("PingBatchId");

                    b.ToTable("PingResult");
                });

            modelBuilder.Entity("PingMonitor.Service.PingResult", b =>
                {
                    b.HasOne("PingMonitor.Service.PingBatch")
                        .WithMany("Results")
                        .HasForeignKey("PingBatchId");
                });
#pragma warning restore 612, 618
        }
    }
}
