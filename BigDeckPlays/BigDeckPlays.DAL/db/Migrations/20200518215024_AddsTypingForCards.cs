using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BigDeckPlays.DAL.db.Migrations
{
    public partial class AddsTypingForCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cost",
                schema: "dbo",
                table: "card_face");

            migrationBuilder.DropColumn(
                name: "cost",
                schema: "dbo",
                table: "card");

            migrationBuilder.RenameColumn(
                name: "toughness",
                schema: "dbo",
                table: "card",
                newName: "loyalty");

            migrationBuilder.RenameColumn(
                name: "sub_types",
                schema: "dbo",
                table: "card",
                newName: "subtypes");

            migrationBuilder.RenameColumn(
                name: "colors",
                schema: "dbo",
                table: "card",
                newName: "color_identity");

            migrationBuilder.AddColumn<string>(
                name: "mana_cost",
                schema: "dbo",
                table: "card_face",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "brawl_legality",
                schema: "dbo",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorIdentity",
                schema: "dbo",
                table: "card",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "commander_legality",
                schema: "dbo",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "edhrec_rank",
                schema: "dbo",
                table: "card",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Loyalty",
                schema: "dbo",
                table: "card",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "mana_cost",
                schema: "dbo",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "modern_legality",
                schema: "dbo",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "oracle_id",
                schema: "dbo",
                table: "card",
                type: "UUID",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "pioneer_legality",
                schema: "dbo",
                table: "card",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "reserved",
                schema: "dbo",
                table: "card",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "standard_legality",
                schema: "dbo",
                table: "card",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mana_cost",
                schema: "dbo",
                table: "card_face");

            migrationBuilder.DropColumn(
                name: "brawl_legality",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "ColorIdentity",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "commander_legality",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "edhrec_rank",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "Loyalty",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "mana_cost",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "modern_legality",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "oracle_id",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "pioneer_legality",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "reserved",
                schema: "dbo",
                table: "card");

            migrationBuilder.DropColumn(
                name: "standard_legality",
                schema: "dbo",
                table: "card");

            migrationBuilder.RenameColumn(
                name: "loyalty",
                schema: "dbo",
                table: "card",
                newName: "toughness");

            migrationBuilder.RenameColumn(
                name: "subtypes",
                schema: "dbo",
                table: "card",
                newName: "sub_types");

            migrationBuilder.RenameColumn(
                name: "color_identity",
                schema: "dbo",
                table: "card",
                newName: "colors");

            migrationBuilder.AddColumn<string>(
                name: "cost",
                schema: "dbo",
                table: "card_face",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cost",
                schema: "dbo",
                table: "card",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);
        }
    }
}
