using Microsoft.EntityFrameworkCore.Migrations;

namespace BigDeckPlays.DAL.db.Migrations
{
    public partial class AddsCompletedColumnToSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "completed",
                schema: "dbo",
                table: "set",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "completed",
                schema: "dbo",
                table: "set");
        }
    }
}
