﻿// <auto-generated />
using System;
using GraphQlMaster.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQlMaster.Core.Migrations
{
    [DbContext(typeof(MarketingContext))]
    [Migration("20200531094408_InitialCreateV2")]
    partial class InitialCreateV2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GraphQlMaster.ServiceFoundation.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FoundedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("GraphQlMaster.ServiceFoundation.Models.Material", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId");

                    b.Property<string>("Name");

                    b.Property<int>("Piece");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Materials");
                });

            modelBuilder.Entity("GraphQlMaster.ServiceFoundation.Models.PurchaseHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("MaterialId");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.ToTable("PurchaseHistories");
                });

            modelBuilder.Entity("GraphQlMaster.ServiceFoundation.Models.Material", b =>
                {
                    b.HasOne("GraphQlMaster.ServiceFoundation.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");
                });

            modelBuilder.Entity("GraphQlMaster.ServiceFoundation.Models.PurchaseHistory", b =>
                {
                    b.HasOne("GraphQlMaster.ServiceFoundation.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");
                });
#pragma warning restore 612, 618
        }
    }
}
