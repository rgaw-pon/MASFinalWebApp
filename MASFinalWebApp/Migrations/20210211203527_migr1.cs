﻿using System;
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsurancePackageID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurancePackage", x => x.InsurancePackageID);
                    table.ForeignKey(
                        name: "FK_InsurancePackage_InsurancePackage_InsurancePackageID1",
                        column: x => x.InsurancePackageID1,
                        principalTable: "InsurancePackage",
                        principalColumn: "InsurancePackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInsurance",
                columns: table => new
                {
                    InsuranceID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInsurance", x => x.InsuranceID);
                    table.ForeignKey(
                        name: "FK_PropertyInsurance_Insurance_InsuranceID",
                        column: x => x.InsuranceID,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportInsurance",
                columns: table => new
                {
                    InsuranceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportInsurance", x => x.InsuranceID);
                    table.ForeignKey(
                        name: "FK_SportInsurance_Insurance_InsuranceID",
                        column: x => x.InsuranceID,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "AutocascoInsurance",
                columns: table => new
                {
                    InsuranceID = table.Column<int>(type: "int", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutocascoInsurance", x => x.InsuranceID);
                    table.ForeignKey(
                        name: "FK_AutocascoInsurance_Insurance_InsuranceID",
                        column: x => x.InsuranceID,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutocascoInsurance_Person_OwnerID",
                        column: x => x.OwnerID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Client_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false),
                    TaxIdentificationNumber = table.Column<int>(type: "int", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salary = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Employee_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.PersonID);
                    table.ForeignKey(
                        name: "FK_Owner_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SportDiscipline",
                columns: table => new
                {
                    SportDisciplineID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportInsuranceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportDiscipline", x => x.SportDisciplineID);
                    table.ForeignKey(
                        name: "FK_SportDiscipline_SportInsurance_SportInsuranceID",
                        column: x => x.SportInsuranceID,
                        principalTable: "SportInsurance",
                        principalColumn: "InsuranceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceAgreement",
                columns: table => new
                {
                    InsuranceAgreementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    BuyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceID = table.Column<int>(type: "int", nullable: true),
                    InsurancePackageID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceAgreement", x => x.InsuranceAgreementID);
                    table.ForeignKey(
                        name: "FK_InsuranceAgreement_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsuranceAgreement_Insurance_InsuranceID",
                        column: x => x.InsuranceID,
                        principalTable: "Insurance",
                        principalColumn: "InsuranceID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InsuranceAgreement_InsurancePackage_InsurancePackageID",
                        column: x => x.InsurancePackageID,
                        principalTable: "InsurancePackage",
                        principalColumn: "InsurancePackageID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Insurer",
                columns: table => new
                {
                    InsurerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsurerLicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerPersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurer", x => x.InsurerID);
                    table.ForeignKey(
                        name: "FK_Insurer_Owner_OwnerPersonID",
                        column: x => x.OwnerPersonID,
                        principalTable: "Owner",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BillingInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceAgreementRefID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceNo);
                    table.ForeignKey(
                        name: "FK_Invoice_InsuranceAgreement_InsuranceAgreementRefID",
                        column: x => x.InsuranceAgreementRefID,
                        principalTable: "InsuranceAgreement",
                        principalColumn: "InsuranceAgreementID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutocascoInsurance_OwnerID",
                table: "AutocascoInsurance",
                column: "OwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAgreement_ClientID",
                table: "InsuranceAgreement",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAgreement_InsuranceID",
                table: "InsuranceAgreement",
                column: "InsuranceID");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAgreement_InsurancePackageID",
                table: "InsuranceAgreement",
                column: "InsurancePackageID");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancePackage_InsurancePackageID1",
                table: "InsurancePackage",
                column: "InsurancePackageID1");

            migrationBuilder.CreateIndex(
                name: "IX_InsurancesInPackages_InsurancePackageID",
                table: "InsurancesInPackages",
                column: "InsurancePackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Insurer_OwnerPersonID",
                table: "Insurer",
                column: "OwnerPersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InsuranceAgreementRefID",
                table: "Invoice",
                column: "InsuranceAgreementRefID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SportDiscipline_SportInsuranceID",
                table: "SportDiscipline",
                column: "SportInsuranceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutocascoInsurance");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "InsurancesInPackages");

            migrationBuilder.DropTable(
                name: "Insurer");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "PropertyInsurance");

            migrationBuilder.DropTable(
                name: "SportDiscipline");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "InsuranceAgreement");

            migrationBuilder.DropTable(
                name: "SportInsurance");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "InsurancePackage");

            migrationBuilder.DropTable(
                name: "Insurance");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
