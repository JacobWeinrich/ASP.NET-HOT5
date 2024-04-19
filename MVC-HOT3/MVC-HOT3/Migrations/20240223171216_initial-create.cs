using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVC_HOT3.Migrations
{
    /// <inheritdoc />
    public partial class initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneOs",
                columns: table => new
                {
                    PhoneOsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneOsName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneOs", x => x.PhoneOsID);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PhoneID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhonePrice = table.Column<double>(type: "float", nullable: false),
                    PhoneOsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.PhoneID);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneOs_PhoneOsID",
                        column: x => x.PhoneOsID,
                        principalTable: "PhoneOs",
                        principalColumn: "PhoneOsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhoneOs",
                columns: new[] { "PhoneOsID", "PhoneOsName" },
                values: new object[,]
                {
                    { 1, "iOS" },
                    { 2, "Android" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "PhoneID", "PhoneBrand", "PhoneImageName", "PhoneModel", "PhoneName", "PhoneOsID", "PhonePrice" },
                values: new object[,]
                {
                    { 1, "Apple", "Phone.png", "A2403", "iPhone 12", 1, 100.0 },
                    { 2, "Samsung", "Phone.png", "SM-G991U", "Galaxy S21", 2, 100.0 },
                    { 3, "Google", "Phone.png", "GD1YQ", "Pixel 5", 2, 100.0 },
                    { 4, "Samsung", "Phone.png", "SM-G991U", "Galaxy S22 Ulta", 2, 100.0 },
                    { 5, "Samsung", "Phone.png", "SM-Z999A", "Galaxy S35 Ulta Super", 2, 100.0 },
                    { 6, "Apple", "Phone.png", "A2403", "iPhone 15", 1, 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneOsID",
                table: "Phones",
                column: "PhoneOsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "PhoneOs");
        }
    }
}
