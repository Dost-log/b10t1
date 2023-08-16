using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class migration_v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "AdminMasters",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char");

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
                name: "ItemMasters",
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
                    table.PrimaryKey("PK_ItemMasters", x => x.itemId);
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
                    EmployeeId1 = table.Column<string>(type: "varchar(6)", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    cardLoanId = table.Column<string>(type: "varchar(6)", nullable: false),
                    issue_date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCards", x => x.EmployeeId);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCards");

            migrationBuilder.DropTable(
                name: "EmployeeIssues");

            migrationBuilder.DropTable(
                name: "ItemMasters");

            migrationBuilder.DropTable(
                name: "EmployeeMasters");

            migrationBuilder.DropTable(
                name: "LoanCardMasters");

            migrationBuilder.AlterColumn<string>(
                name: "gender",
                table: "AdminMasters",
                type: "char",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)");
        }
    }
}
