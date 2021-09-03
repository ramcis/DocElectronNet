using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace VarDoc.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id_patient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nom_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    prenom_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    pere_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    tel_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    fiche_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    date_naissance = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id_patient);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
