using Microsoft.EntityFrameworkCore.Migrations;

namespace BigDeckPlays.DAL.db.Migrations
{
    public partial class RemovesMaxLimitForFaceOracleText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "oracle_text",
                schema: "dbo",
                table: "card_face",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "oracle_text",
                schema: "dbo",
                table: "card_face",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
