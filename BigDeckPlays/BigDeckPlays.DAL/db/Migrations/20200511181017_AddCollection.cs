using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BigDeckPlays.DAL.db.Migrations
{
    public partial class AddCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collection",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "collection_card",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    collection_id = table.Column<int>(nullable: false),
                    card_id = table.Column<string>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collection_card", x => x.id);
                    table.ForeignKey(
                        name: "collection_card_card_id_fkey",
                        column: x => x.card_id,
                        principalSchema: "dbo",
                        principalTable: "card",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "collection_card_collection_id_fkey",
                        column: x => x.collection_id,
                        principalSchema: "dbo",
                        principalTable: "collection",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collection_card_card_id",
                schema: "dbo",
                table: "collection_card",
                column: "card_id");

            migrationBuilder.CreateIndex(
                name: "IX_collection_card_collection_id",
                schema: "dbo",
                table: "collection_card",
                column: "collection_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collection_card",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "collection",
                schema: "dbo");
        }
    }
}
