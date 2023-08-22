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
                name: "AdminMasters",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    name = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    designation = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    gender = table.Column<string>(type: "char(1)", nullable: false),
                    department = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    DOB = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DOJ = table.Column<DateTime>(type: "DateTime", nullable: false),
                    password = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminMasters", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCards",
                columns: table => new
                {
                    emp_card_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    issue_date = table.Column<DateTime>(type: "DateTime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCards", x => x.emp_card_id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeIssues",
                columns: table => new
                {
                    issueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    itemId = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false),
                    issue_date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    return_date = table.Column<DateTime>(type: "DateTime", nullable: false)
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
                    DOJ = table.Column<DateTime>(type: "DateTime", nullable: false),
                    password = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
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
                    status = table.Column<string>(type: "char(1)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanCardMasters", x => x.LoanId);
                });
        }

        /// <inheritdoc />
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
                name: "ItemMasters");

            migrationBuilder.DropTable(
                name: "LoanCardMasters");
        }
    }
}
