using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class AddedPatientMorbidityGroupDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMorbidityGroup_MorbidityGroups_MorbidityGroupId",
                table: "PatientMorbidityGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMorbidityGroup_Patients_PatientId",
                table: "PatientMorbidityGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMorbidityGroup",
                table: "PatientMorbidityGroup");

            migrationBuilder.RenameTable(
                name: "PatientMorbidityGroup",
                newName: "PatientMorbidityGroups");

            migrationBuilder.RenameIndex(
                name: "IX_PatientMorbidityGroup_MorbidityGroupId",
                table: "PatientMorbidityGroups",
                newName: "IX_PatientMorbidityGroups_MorbidityGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMorbidityGroups",
                table: "PatientMorbidityGroups",
                columns: new[] { "PatientId", "MorbidityGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMorbidityGroups_MorbidityGroups_MorbidityGroupId",
                table: "PatientMorbidityGroups",
                column: "MorbidityGroupId",
                principalTable: "MorbidityGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMorbidityGroups_Patients_PatientId",
                table: "PatientMorbidityGroups",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMorbidityGroups_MorbidityGroups_MorbidityGroupId",
                table: "PatientMorbidityGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientMorbidityGroups_Patients_PatientId",
                table: "PatientMorbidityGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientMorbidityGroups",
                table: "PatientMorbidityGroups");

            migrationBuilder.RenameTable(
                name: "PatientMorbidityGroups",
                newName: "PatientMorbidityGroup");

            migrationBuilder.RenameIndex(
                name: "IX_PatientMorbidityGroups_MorbidityGroupId",
                table: "PatientMorbidityGroup",
                newName: "IX_PatientMorbidityGroup_MorbidityGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientMorbidityGroup",
                table: "PatientMorbidityGroup",
                columns: new[] { "PatientId", "MorbidityGroupId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMorbidityGroup_MorbidityGroups_MorbidityGroupId",
                table: "PatientMorbidityGroup",
                column: "MorbidityGroupId",
                principalTable: "MorbidityGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMorbidityGroup_Patients_PatientId",
                table: "PatientMorbidityGroup",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
