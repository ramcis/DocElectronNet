// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VarDoc;

namespace VarDoc.Migrations
{
    [DbContext(typeof(DocDbContext))]
    [Migration("20210904155957_cascade")]
    partial class cascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("VarDoc.Models.FicheP", b =>
                {
                    b.Property<int>("id_fiche")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("anticedent")
                        .HasColumnType("nvarchar (250)");

                    b.Property<string>("anticedent_churgical")
                        .HasColumnType("nvarchar (250)");

                    b.Property<string>("anticedent_medical")
                        .HasColumnType("nvarchar (250)");

                    b.Property<string>("ficheNo")
                        .HasColumnType("nvarchar (250)");

                    b.Property<int>("id_patient")
                        .HasColumnType("int");

                    b.Property<string>("job")
                        .HasColumnType("nvarchar (250)");

                    b.HasKey("id_fiche");

                    b.HasIndex("id_patient");

                    b.ToTable("FicheP");
                });

            modelBuilder.Entity("VarDoc.Models.Patients", b =>
                {
                    b.Property<int>("id_patient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("date_naissance")
                        .HasColumnType("datetime");

                    b.Property<string>("fiche_patient")
                        .HasColumnType("nvarchar (250)");

                    b.Property<string>("nom_patient")
                        .HasColumnType("nvarchar (250)");

                    b.Property<string>("pere_patient")
                        .HasColumnType("nvarchar (250)");

                    b.Property<string>("prenom_patient")
                        .HasColumnType("nvarchar (250)");

                    b.Property<string>("tel_patient")
                        .HasColumnType("nvarchar (250)");

                    b.HasKey("id_patient");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("VarDoc.Models.FicheP", b =>
                {
                    b.HasOne("VarDoc.Models.Patients", "Patients")
                        .WithMany("FichePs")
                        .HasForeignKey("id_patient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patients");
                });

            modelBuilder.Entity("VarDoc.Models.Patients", b =>
                {
                    b.Navigation("FichePs");
                });
#pragma warning restore 612, 618
        }
    }
}
