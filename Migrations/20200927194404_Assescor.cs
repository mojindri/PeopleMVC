using Microsoft.EntityFrameworkCore.Migrations;

namespace assessment_server_side.Migrations
{
    public partial class Assescor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(maxLength: 50, nullable: true),
                    Zipcode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    Fav_colour_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.id);
                    table.ForeignKey(
                        name: "FK_Person_Color",
                        column: x => x.Fav_colour_id,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_Fav_colour_id",
                table: "Person",
                column: "Fav_colour_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Color");
        }
    }
}
