using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VarDoc.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id_patient = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nom_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    prenom_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    pere_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    tel_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    fiche_patient = table.Column<string>(type: "varchar (250)", nullable: true),
                    date_naissance = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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
