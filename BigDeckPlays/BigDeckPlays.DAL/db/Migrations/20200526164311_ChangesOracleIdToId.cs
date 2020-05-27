using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigDeckPlays.DAL.db.Migrations
{
    public partial class ChangesOracleIdToId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "oracle_id",
                schema: "dbo",
                table: "card");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "oracle_id",
                schema: "dbo",
                table: "card",
                type: "UUID",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
