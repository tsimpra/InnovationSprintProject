using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDataAccessLibrary.Migrations
{
    public partial class AddedUniqueOnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SymptomInstances_Name",
                table: "SymptomInstances",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MorbidityGroups_Name",
                table: "MorbidityGroups",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SymptomInstances_Name",
                table: "SymptomInstances");

            migrationBuilder.DropIndex(
                name: "IX_MorbidityGroups_Name",
                table: "MorbidityGroups");
        }
    }
}
