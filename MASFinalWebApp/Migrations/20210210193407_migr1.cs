using Microsoft.EntityFrameworkCore.Migrations;

namespace MASFinalWebApp.Migrations
{
    public partial class migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Insurance",
                columns: table => new
                {
                    InsuranceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InsuranceAmount = table.Column<float>(type: "real", nullable: false),
                    InsuranceRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeneralTermsAndConditions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance", x => x.InsuranceID);
                });

            migrationBuilder.CreateTable(
                name: "InsurancePackage",
                columns: table => new
                {
                    InsurancePackageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePackage", x => x.InsurancePackageID);
                });

            migrationBuilder.CreateTable(
                name: "InsurancesInPackages",
                columns: table => new
                {
                    InsuranceID = table.Column<int>(type: "int", nullable: false),
                    InsurancePackageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancesInPackages", x => new { x.InsuranceID, x.InsurancePackageID });
                    table.ForeignKey(
                        name: "FK_InsurancesInPackages_Insurance_InsuranceID",
                        column: x => x.InsuranceID,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsurancesInPackages_InsurancePackage_InsurancePackageID",
                        column: x => x.InsurancePackageID,
                        principalTable: "InsurancePackage",
                        principalColumn: "InsurancePackageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsurancesInPackages_InsurancePackageID",
                table: "InsurancesInPackages",
                column: "InsurancePackageID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsurancesInPackages");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "InsurancePackage");
        }
    }
}
