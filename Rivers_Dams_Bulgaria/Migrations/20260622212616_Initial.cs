using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rivers_Dams_Bulgaria.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rivers",
                columns: table => new
                {
                    RiverId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    SourceLocation = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MouthLocation = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rivers", x => x.RiverId);
                });

            migrationBuilder.CreateTable(
                name: "Dams",
                columns: table => new
                {
                    DamId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    Length = table.Column<double>(type: "REAL", nullable: false),
                    YearBuilt = table.Column<int>(type: "INTEGER", nullable: false),
                    RiverId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dams", x => x.DamId);
                    table.ForeignKey(
                        name: "FK_Dams_Rivers_RiverId",
                        column: x => x.RiverId,
                        principalTable: "Rivers",
                        principalColumn: "RiverId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservoirs",
                columns: table => new
                {
                    ReservoirId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Area = table.Column<double>(type: "REAL", nullable: false),
                    Capacity = table.Column<double>(type: "REAL", nullable: false),
                    DamId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservoirs", x => x.ReservoirId);
                    table.ForeignKey(
                        name: "FK_Reservoirs_Dams_DamId",
                        column: x => x.DamId,
                        principalTable: "Dams",
                        principalColumn: "DamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dams_RiverId",
                table: "Dams",
                column: "RiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservoirs_DamId",
                table: "Reservoirs",
                column: "DamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservoirs");

            migrationBuilder.DropTable(
                name: "Dams");

            migrationBuilder.DropTable(
                name: "Rivers");
        }
    }
}
