using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Book_Dal.Migrations
{
    /// <inheritdoc />
    public partial class addconutry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CityId",
                table: "Reservations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CountryId",
                table: "Reservations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StateId",
                table: "Reservations",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cities_CityId",
                table: "Reservations",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Countries_CountryId",
                table: "Reservations",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_States_StateId",
                table: "Reservations",
                column: "StateId",
                principalTable: "States",
                principalColumn: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cities_CityId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Countries_CountryId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_States_StateId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CityId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CountryId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StateId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Reservations");
        }
    }
}
