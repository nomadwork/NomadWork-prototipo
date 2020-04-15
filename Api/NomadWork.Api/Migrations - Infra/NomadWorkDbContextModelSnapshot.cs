﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NomadWork.Api.Context;

namespace NomadWork.Api.Migrations
{
    [DbContext(typeof(NomadWorkDbContext))]
    partial class NomadWorkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NomadWork.Api.Models.AddressModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(6)");

                    b.Property<string>("Coutry")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(8,8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(8,8)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("NomadWork.Api.Models.CharacteristicModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(6)");

                    b.Property<string>("EstablishmmentModelId");

                    b.Property<short>("HasNotHas");

                    b.Property<short>("ServiceOffered");

                    b.Property<short>("ServiceOfferedQuality");

                    b.HasKey("Id");

                    b.HasIndex("EstablishmmentModelId");

                    b.ToTable("CharacteristicModel");
                });

            modelBuilder.Entity("NomadWork.Api.Models.EstablishmmentModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(6)");

                    b.Property<string>("AddressId")
                        .IsRequired();

                    b.Property<string>("OwnerId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Establishmment");
                });

            modelBuilder.Entity("NomadWork.Api.Models.UserModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("char(6)");

                    b.Property<bool>("Active");

                    b.Property<string>("AddressId")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumberPhone")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("NomadWork.Api.Models.CharacteristicModel", b =>
                {
                    b.HasOne("NomadWork.Api.Models.EstablishmmentModel")
                        .WithMany("Characteristics")
                        .HasForeignKey("EstablishmmentModelId");
                });

            modelBuilder.Entity("NomadWork.Api.Models.EstablishmmentModel", b =>
                {
                    b.HasOne("NomadWork.Api.Models.AddressModel", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NomadWork.Api.Models.UserModel", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NomadWork.Api.Models.UserModel", b =>
                {
                    b.HasOne("NomadWork.Api.Models.AddressModel", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
