using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BigDeckPlays.DAL.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "card",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    cmc = table.Column<int>(nullable: true),
                    cost = table.Column<string>(maxLength: 255, nullable: true),
                    oracle_text = table.Column<string>(maxLength: 255, nullable: true),
                    power = table.Column<string>(maxLength: 255, nullable: true),
                    toughness = table.Column<string>(maxLength: 255, nullable: true),
                    types = table.Column<string>(maxLength: 255, nullable: true),
                    sub_types = table.Column<string>(maxLength: 255, nullable: true),
                    colors = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "set",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 255, nullable: false),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    border = table.Column<string>(maxLength: 255, nullable: true),
                    type = table.Column<string>(maxLength: 255, nullable: true),
                    url = table.Column<string>(maxLength: 255, nullable: true),
                    number = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_set", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "deck",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false),
                    commander = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deck", x => x.id);
                    table.ForeignKey(
                        name: "deck_commander_fkey",
                        column: x => x.commander,
                        principalSchema: "dbo",
                        principalTable: "card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "card_set",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    card_id = table.Column<string>(maxLength: 255, nullable: false),
                    set_id = table.Column<string>(maxLength: 255, nullable: false),
                    high_price = table.Column<decimal>(type: "numeric", nullable: true),
                    median_price = table.Column<decimal>(type: "numeric", nullable: true),
                    low_price = table.Column<decimal>(type: "numeric", nullable: true),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card_set", x => x.id);
                    table.ForeignKey(
                        name: "card_set_card_id_fkey",
                        column: x => x.card_id,
                        principalSchema: "dbo",
                        principalTable: "card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "card_set_set_id_fkey",
                        column: x => x.set_id,
                        principalSchema: "dbo",
                        principalTable: "set",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "card_tag",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    card_id = table.Column<string>(maxLength: 255, nullable: false),
                    tag_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_card_tag", x => x.id);
                    table.ForeignKey(
                        name: "card_tag_card_id_fkey",
                        column: x => x.card_id,
                        principalSchema: "dbo",
                        principalTable: "card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "card_tag_tag_id_fkey",
                        column: x => x.tag_id,
                        principalSchema: "dbo",
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "deck_card",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deck_id = table.Column<int>(nullable: false),
                    card_id = table.Column<string>(maxLength: 255, nullable: false),
                    quantity = table.Column<int>(nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deck_card", x => x.id);
                    table.ForeignKey(
                        name: "deck_card_card_id_fkey",
                        column: x => x.card_id,
                        principalSchema: "dbo",
                        principalTable: "card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "deck_card_deck_id_fkey",
                        column: x => x.deck_id,
                        principalSchema: "dbo",
                        principalTable: "deck",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "deck_tag",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    deck_id = table.Column<int>(nullable: false),
                    tag_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false, defaultValueSql: "1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deck_tag", x => x.id);
                    table.ForeignKey(
                        name: "deck_tag_deck_id_fkey",
                        column: x => x.deck_id,
                        principalSchema: "dbo",
                        principalTable: "deck",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "deck_tag_tag_id_fkey",
                        column: x => x.tag_id,
                        principalSchema: "dbo",
                        principalTable: "tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "card_name_key",
                schema: "dbo",
                table: "card",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_card_set_card_id",
                schema: "dbo",
                table: "card_set",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_set_set_id",
                schema: "dbo",
                table: "card_set",
                column: "set_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_tag_card_id",
                schema: "dbo",
                table: "card_tag",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "IX_card_tag_tag_id",
                schema: "dbo",
                table: "card_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_deck_commander",
                schema: "dbo",
                table: "deck",
                column: "commander");

            migrationBuilder.CreateIndex(
                name: "deck_name_key",
                schema: "dbo",
                table: "deck",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_deck_card_card_id",
                schema: "dbo",
                table: "deck_card",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "IX_deck_card_deck_id",
                schema: "dbo",
                table: "deck_card",
                column: "deck_id");

            migrationBuilder.CreateIndex(
                name: "IX_deck_tag_deck_id",
                schema: "dbo",
                table: "deck_tag",
                column: "deck_id");

            migrationBuilder.CreateIndex(
                name: "IX_deck_tag_tag_id",
                schema: "dbo",
                table: "deck_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "set_name_key",
                schema: "dbo",
                table: "set",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card_set",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "card_tag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deck_card",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deck_tag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "set",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "deck",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tag",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "card",
                schema: "dbo");
        }
    }
}
