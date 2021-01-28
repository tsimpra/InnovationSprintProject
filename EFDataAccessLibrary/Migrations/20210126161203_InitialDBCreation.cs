using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MorbidityGroups",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MorbidityGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Dob = table.Column<DateTime>(type: "Date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientMorbidityGroup",
                columns: table => new
                {
                    PatientId = table.Column<long>(nullable: false),
                    MorbidityGroupId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMorbidityGroup", x => new { x.PatientId, x.MorbidityGroupId });
                    table.ForeignKey(
                        name: "FK_PatientMorbidityGroup_MorbidityGroups_MorbidityGroupId",
                        column: x => x.MorbidityGroupId,
                        principalTable: "MorbidityGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMorbidityGroup_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SymptomInstances",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PatientId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomInstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SymptomInstances_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMorbidityGroup_MorbidityGroupId",
                table: "PatientMorbidityGroup",
                column: "MorbidityGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SymptomInstances_PatientId",
                table: "SymptomInstances",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientMorbidityGroup");

            migrationBuilder.DropTable(
                name: "SymptomInstances");

            migrationBuilder.DropTable(
                name: "MorbidityGroups");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
