using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LawOffice.Infrastructure.Migrations
{
    public partial class ApplicationUserAndAllTablesnoConnectionWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsideCaseNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    InsideCaseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CaseDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfLaw = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InfoAboutLaw = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProblemType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    UrgencyType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TypeOfAnswer = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    StatusOfTheOrder = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfInstance = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CaseNumberByTheInstance = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CaseNumberDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Session = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Instances_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsideDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfTheDocument = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfCreating = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyOutGoingNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RecipientЕntranceNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TheDocumentInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsideDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsideDocuments_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutsideDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfTheDocument = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OriginalNumberOfTheDocument = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    OriginalDateOfTheDocument = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheDocumentInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheDocument = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutsideDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutsideDocuments_Instances_InstanceId",
                        column: x => x.InstanceId,
                        principalTable: "Instances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsideDocuments_InstanceId",
                table: "InsideDocuments",
                column: "InstanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Instances_CaseId",
                table: "Instances",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_OutsideDocuments_InstanceId",
                table: "OutsideDocuments",
                column: "InstanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInfos");

            migrationBuilder.DropTable(
                name: "InsideDocuments");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OutsideDocuments");

            migrationBuilder.DropTable(
                name: "Instances");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
