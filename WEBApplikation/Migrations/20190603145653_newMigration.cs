using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WEBApplikation.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Road = table.Column<string>(nullable: false),
                    RoadNumber = table.Column<string>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    SensorId = table.Column<string>(maxLength: 16, nullable: false),
                    Species = table.Column<string>(nullable: false),
                    Latitude = table.Column<double>(nullable: false),
                    Lontitude = table.Column<double>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.SensorId);
                    table.ForeignKey(
                        name: "FK_Sensors_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trees",
                columns: table => new
                {
                    TreeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    Species = table.Column<string>(nullable: false),
                    LocationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trees", x => x.TreeId);
                    table.ForeignKey(
                        name: "FK_Trees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "City", "Name", "PostalCode", "Road", "RoadNumber" },
                values: new object[] { 1, "Århus", "Ringgaden", 8210, "Ringgaden", "22" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "City", "Name", "PostalCode", "Road", "RoadNumber" },
                values: new object[] { 2, "Århus", "Randersvej", 8000, "Randersvej", "43" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "SensorId", "Latitude", "LocationId", "Lontitude", "Species" },
                values: new object[,]
                {
                    { "0000000000000001", 56.1629, 1, 10.203900000000001, "Bøg" },
                    { "0000000000000002", 56.162399999999998, 1, 10.203099999999999, "Bøg" },
                    { "0000000000000003", 56.162799999999997, 1, 10.203200000000001, "Birk" },
                    { "0000000000000004", 56.149999999999999, 2, 10.199999999999999, "Eg" },
                    { "0000000000000005", 56.150199999999998, 2, 10.2065, "Ask" },
                    { "0000000000000006", 56.152200000000001, 2, 10.204499999999999, "Eg" },
                    { "0000000000000007", 56.150100000000002, 2, 10.24, "Eg" },
                    { "0000000000000008", 56.152999999999999, 2, 10.202, "Ask" }
                });

            migrationBuilder.InsertData(
                table: "Trees",
                columns: new[] { "TreeId", "Amount", "LocationId", "Species" },
                values: new object[,]
                {
                    { 1, 5, 1, "Bøg" },
                    { 2, 2, 1, "Birk" },
                    { 3, 15, 2, "Eg" },
                    { 4, 2, 2, "Ask" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_LocationId",
                table: "Sensors",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Trees_LocationId",
                table: "Trees",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "Trees");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
