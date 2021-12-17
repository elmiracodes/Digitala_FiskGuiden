using Microsoft.EntityFrameworkCore.Migrations;

namespace Digitala_FiskGuiden.Migrations
{
    public partial class NewTableWithFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlassId",
                table: "Fiskar",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fiskar_KlassId",
                table: "Fiskar",
                column: "KlassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fiskar_Klasser_KlassId",
                table: "Fiskar",
                column: "KlassId",
                principalTable: "Klasser",
                principalColumn: "KlassId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fiskar_Klasser_KlassId",
                table: "Fiskar");

            migrationBuilder.DropIndex(
                name: "IX_Fiskar_KlassId",
                table: "Fiskar");

            migrationBuilder.DropColumn(
                name: "KlassId",
                table: "Fiskar");
        }
    }
}
