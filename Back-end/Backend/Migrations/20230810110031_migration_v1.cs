using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class migration_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "ItemMasters",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldMaxLength: 25);

            migrationBuilder.CreateTable(
                name: "AdminMasters",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    designation = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    gender = table.Column<string>(type: "char(1)", nullable: false),
                    department = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    DOB = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DOJ = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMasters", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIssues",
                columns: table => new
                {
                    issueId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    itemId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    Designation = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    return_date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    issue_date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeIssues", x => x.issueId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMasters",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    designation = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    gender = table.Column<string>(type: "char(1)", nullable: false),
                    department = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    DOB = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DOJ = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMasters", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "LoanCardMasters",
                columns: table => new
                {
                    LoanId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    loan_type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCardMasters", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCards",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    EmployeeId1 = table.Column<string>(type: "varchar(6)", nullable: false),
                    cardLoanId = table.Column<string>(type: "varchar(6)", nullable: false),
                    issue_date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCards", x => new { x.LoanId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeCards_EmployeeMasters_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "EmployeeMasters",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCards_LoanCardMasters_cardLoanId",
                        column: x => x.cardLoanId,
                        principalTable: "LoanCardMasters",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCards_cardLoanId",
                table: "EmployeeCards",
                column: "cardLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCards_EmployeeId1",
                table: "EmployeeCards",
                column: "EmployeeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMasters");

            migrationBuilder.DropTable(
                name: "EmployeeCards");

            migrationBuilder.DropTable(
                name: "EmployeeIssues");

            migrationBuilder.DropTable(
                name: "EmployeeMasters");

            migrationBuilder.DropTable(
                name: "LoanCardMasters");

            migrationBuilder.AlterColumn<string>(
                name: "category",
                table: "ItemMasters",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20);
        }
    }
}
