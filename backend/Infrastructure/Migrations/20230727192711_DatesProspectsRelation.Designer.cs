﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230727192711_DatesProspectsRelation")]
    partial class DatesProspectsRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("Domain.Requested.Models.Prospect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Available")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateOnly>("Birth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Goal")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Prospects");
                });

            modelBuilder.Entity("Domain.Requester.Models.Date", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Contribution")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Displacement")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ProspectId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProspectId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("Domain.Requester.Models.Date", b =>
                {
                    b.HasOne("Domain.Requested.Models.Prospect", "Prospect")
                        .WithMany("Dates")
                        .HasForeignKey("ProspectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prospect");
                });

            modelBuilder.Entity("Domain.Requested.Models.Prospect", b =>
                {
                    b.Navigation("Dates");
                });
#pragma warning restore 612, 618
        }
    }
}
