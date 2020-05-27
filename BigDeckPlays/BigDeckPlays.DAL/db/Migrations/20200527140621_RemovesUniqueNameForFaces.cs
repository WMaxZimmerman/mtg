using Microsoft.EntityFrameworkCore.Migrations;

namespace BigDeckPlays.DAL.db.Migrations
{
    public partial class RemovesUniqueNameForFaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "card_face_name_key",
                schema: "dbo",
                table: "card_face");

            migrationBuilder.CreateIndex(
                name: "card_face_name_key",
                schema: "dbo",
                table: "card_face",
                column: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "card_face_name_key",
                schema: "dbo",
                table: "card_face");

            migrationBuilder.CreateIndex(
                name: "card_face_name_key",
                schema: "dbo",
                table: "card_face",
                column: "name",
                unique: true);
        }
    }
}
