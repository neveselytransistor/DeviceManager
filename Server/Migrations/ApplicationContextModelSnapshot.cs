﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server;

namespace Server.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("Server.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Info");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("Server.Models.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrandId");

                    b.Property<string>("Info");

                    b.Property<decimal>("Price");

                    b.Property<int?>("ToolId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ToolId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("Server.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Application");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tool");
                });

            modelBuilder.Entity("Server.Models.Equipment", b =>
                {
                    b.HasOne("Server.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("Server.Models.Tool", "Tool")
                        .WithMany()
                        .HasForeignKey("ToolId");
                });
#pragma warning restore 612, 618
        }
    }
}
