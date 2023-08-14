using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class migration_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminMaster",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    password = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMaster", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIssue",
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
                    table.PrimaryKey("PK_EmployeeIssue", x => x.issueId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMaster",
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
                    table.PrimaryKey("PK_EmployeeMaster", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "ItemMaster",
                columns: table => new
                {
                    itemId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    descprition = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    make = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    status = table.Column<string>(type: "char(1)", nullable: false),
                    category = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    valuation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMaster", x => x.itemId);
                });

            migrationBuilder.CreateTable(
                name: "LoanCardMaster",
                columns: table => new
                {
                    LoanId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    loan_type = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCardMaster", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCard",
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
                    table.PrimaryKey("PK_EmployeeCard", x => new { x.LoanId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_EmployeeCard_EmployeeMaster_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "EmployeeMaster",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCard_LoanCardMaster_cardLoanId",
                        column: x => x.cardLoanId,
                        principalTable: "LoanCardMaster",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCard_cardLoanId",
                table: "EmployeeCard",
                column: "cardLoanId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCard_EmployeeId1",
                table: "EmployeeCard",
                column: "EmployeeId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminMaster");

            migrationBuilder.DropTable(
                name: "EmployeeCard");

            migrationBuilder.DropTable(
                name: "EmployeeIssue");

            migrationBuilder.DropTable(
                name: "ItemMaster");

            migrationBuilder.DropTable(
                name: "EmployeeMaster");

            migrationBuilder.DropTable(
                name: "LoanCardMaster");
        }
    }
}
