using Microsoft.EntityFrameworkCore.Migrations;

namespace Digitala_FiskGuiden.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fiskar",
                columns: table => new
                {
                    FiskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Art = table.Column<string>(type: "TEXT", nullable: true),
                    Fakta = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fiskar", x => x.FiskId);
                });

            migrationBuilder.CreateTable(
                name: "Klasser",
                columns: table => new
                {
                    KlassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FiskKlass = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasser", x => x.KlassId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fiskar");

            migrationBuilder.DropTable(
                name: "Klasser");
        }
    }
}
