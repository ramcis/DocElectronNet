using Microsoft.EntityFrameworkCore.Migrations;

namespace VarDoc.Migrations
{
    public partial class cascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheP_Patients_id_patient",
                table: "FicheP");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheP_Patients_id_patient",
                table: "FicheP",
                column: "id_patient",
                principalTable: "Patients",
                principalColumn: "id_patient",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheP_Patients_id_patient",
                table: "FicheP");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheP_Patients_id_patient",
                table: "FicheP",
                column: "id_patient",
                principalTable: "Patients",
                principalColumn: "id_patient",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
