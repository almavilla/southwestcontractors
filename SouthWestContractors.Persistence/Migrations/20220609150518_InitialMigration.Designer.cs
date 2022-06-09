﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SouthWestContractors.Persistence;

namespace SouthWestContractors.Persistence.Migrations
{
    [DbContext(typeof(SouthWestContractorsDbContext))]
    [Migration("20220609150518_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Plumbing"
                        },
                        new
                        {
                            CategoryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Woodworking"
                        },
                        new
                        {
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Electrical"
                        },
                        new
                        {
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tile"
                        });
                });

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.Contractor", b =>
                {
                    b.Property<Guid>("ContractorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractorId");

                    b.ToTable("Contractors");

                    b.HasData(
                        new
                        {
                            ContractorId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Egbert",
                            Name = "John",
                            UserId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b")
                        },
                        new
                        {
                            ContractorId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Johnson",
                            Name = "Mark",
                            UserId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c01")
                        },
                        new
                        {
                            ContractorId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529318"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Romanov",
                            Name = "Mike",
                            UserId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319")
                        });
                });

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.ContractorCategory", b =>
                {
                    b.Property<Guid>("ContractorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ContractorId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ContractorCategory");

                    b.HasData(
                        new
                        {
                            ContractorId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a"),
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde")
                        },
                        new
                        {
                            ContractorId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            CategoryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6")
                        },
                        new
                        {
                            ContractorId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529318"),
                            CategoryId = new Guid("fe98f549-e790-4e9f-aa16-18c2292a2ee9")
                        },
                        new
                        {
                            ContractorId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529318"),
                            CategoryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde")
                        });
                });

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.Galery", b =>
                {
                    b.Property<Guid>("GaleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ContractorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GaleryId");

                    b.HasIndex("ContractorId");

                    b.ToTable("Galeries");

                    b.HasData(
                        new
                        {
                            GaleryId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dd1"),
                            ContractorId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "uno",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg"
                        },
                        new
                        {
                            GaleryId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a2"),
                            ContractorId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8a"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "dos",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg"
                        },
                        new
                        {
                            GaleryId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284a3"),
                            ContractorId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "tres",
                            ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg"
                        });
                });

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.ContractorCategory", b =>
                {
                    b.HasOne("SouthWestContractors.Domain.Entities.Category", "Category")
                        .WithMany("ContractorCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SouthWestContractors.Domain.Entities.Contractor", "Contractor")
                        .WithMany("ContractorCategories")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.Galery", b =>
                {
                    b.HasOne("SouthWestContractors.Domain.Entities.Contractor", "Contractor")
                        .WithMany("Galery")
                        .HasForeignKey("ContractorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contractor");
                });

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.Category", b =>
                {
                    b.Navigation("ContractorCategories");
                });

            modelBuilder.Entity("SouthWestContractors.Domain.Entities.Contractor", b =>
                {
                    b.Navigation("ContractorCategories");

                    b.Navigation("Galery");
                });
#pragma warning restore 612, 618
        }
    }
}