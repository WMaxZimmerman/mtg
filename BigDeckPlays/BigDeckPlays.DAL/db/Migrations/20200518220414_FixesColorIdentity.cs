using Microsoft.EntityFrameworkCore.Migrations;

namespace BigDeckPlays.DAL.db.Migrations
{
    public partial class FixesColorIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorIdentity",
                schema: "dbo",
                table: "card");

            migrationBuilder.AddColumn<string>(
                name: "colors",
                schema: "dbo",
                table: "card",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "colors",
                schema: "dbo",
                table: "card");

            migrationBuilder.AddColumn<string>(
                name: "ColorIdentity",
                schema: "dbo",
                table: "card",
                type: "text",
                nullable: true);
        }
    }
}
