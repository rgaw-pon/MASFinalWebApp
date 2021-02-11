using Microsoft.EntityFrameworkCore.Migrations;

namespace MASFinalWebApp.Migrations
{
    public partial class migr3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Owner_OwnerPersonID",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_OwnerPersonID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "OwnerPersonID",
                table: "Person");

            migrationBuilder.AddColumn<int>(
                name: "InvoiceID",
                table: "InsuranceAgreement",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "InvoiceNo",
                table: "InsuranceAgreement",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Insurance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAgreement_InvoiceNo",
                table: "InsuranceAgreement",
                column: "InvoiceNo");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceAgreement_Invoice_InvoiceNo",
                table: "InsuranceAgreement",
                column: "InvoiceNo",
                principalTable: "Invoice",
                principalColumn: "InvoiceNo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceAgreement_Invoice_InvoiceNo",
                table: "InsuranceAgreement");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceAgreement_InvoiceNo",
                table: "InsuranceAgreement");

            migrationBuilder.DropColumn(
                name: "InvoiceID",
                table: "InsuranceAgreement");

            migrationBuilder.DropColumn(
                name: "InvoiceNo",
                table: "InsuranceAgreement");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Insurance");

            migrationBuilder.AddColumn<int>(
                name: "OwnerPersonID",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_OwnerPersonID",
                table: "Person",
                column: "OwnerPersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Owner_OwnerPersonID",
                table: "Person",
                column: "OwnerPersonID",
                principalTable: "Owner",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
