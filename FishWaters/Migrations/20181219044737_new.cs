using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FishWaters.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fishtypes",
                columns: table => new
                {
                    FishtypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FishtypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishtypes", x => x.FishtypeID);
                });

            migrationBuilder.CreateTable(
                name: "Waterbodies",
                columns: table => new
                {
                    WaterbodyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LakeName = table.Column<string>(nullable: false),
                    Acres = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    County = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waterbodies", x => x.WaterbodyID);
                });

            migrationBuilder.CreateTable(
                name: "FishWaters",
                columns: table => new
                {
                    FishWaterID = table.Column<int>(nullable: false),
                    WaterbodyID = table.Column<int>(nullable: false),
                    FishtypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishWaters", x => new { x.WaterbodyID, x.FishtypeID });
                    table.ForeignKey(
                        name: "FK_FishWaters_Fishtypes_FishtypeID",
                        column: x => x.FishtypeID,
                        principalTable: "Fishtypes",
                        principalColumn: "FishtypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishWaters_Waterbodies_WaterbodyID",
                        column: x => x.WaterbodyID,
                        principalTable: "Waterbodies",
                        principalColumn: "WaterbodyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FishWaters_FishtypeID",
                table: "FishWaters",
                column: "FishtypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishWaters");

            migrationBuilder.DropTable(
                name: "Fishtypes");

            migrationBuilder.DropTable(
                name: "Waterbodies");
        }
    }
}
