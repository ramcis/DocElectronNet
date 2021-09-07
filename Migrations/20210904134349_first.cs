using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace VarDoc.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id_patient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom_patient = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    prenom_patient = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    pere_patient = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    date_naissance = table.Column<DateTime>(type: "datetime", nullable: false),
                    tel_patient = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    fiche_patient = table.Column<string>(type: "nvarchar (250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id_patient);
                });

            migrationBuilder.CreateTable(
                name: "FicheP",
                columns: table => new
                {
                    id_fiche = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    job = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    anticedent = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    anticedent_churgical = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    anticedent_medical = table.Column<string>(type: "nvarchar (250)", nullable: true),
                    id_patient = table.Column<int>(type: "int", nullable: false),
                    ficheNo = table.Column<string>(type: "nvarchar (250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheP", x => x.id_fiche);
                    table.ForeignKey(
                        name: "FK_FicheP_Patients_id_patient",
                        column: x => x.id_patient,
                        principalTable: "Patients",
                        principalColumn: "id_patient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FicheP_id_patient",
                table: "FicheP",
                column: "id_patient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FicheP");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
