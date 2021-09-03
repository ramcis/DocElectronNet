﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VarDoc;

namespace VarDoc.Migrations
{
    [DbContext(typeof(DocDbContext))]
    partial class DocDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("VarDoc.Models.Patients", b =>
                {
                    b.Property<int>("id_patient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("date_naissance")
                        .HasColumnType("datetime");

                    b.Property<string>("fiche_patient")
                        .HasColumnType("varchar (250)");

                    b.Property<string>("nom_patient")
                        .HasColumnType("varchar (250)");

                    b.Property<string>("pere_patient")
                        .HasColumnType("varchar (250)");

                    b.Property<string>("prenom_patient")
                        .HasColumnType("varchar (250)");

                    b.Property<string>("tel_patient")
                        .HasColumnType("varchar (250)");

                    b.HasKey("id_patient");

                    b.ToTable("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}
