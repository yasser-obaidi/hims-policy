using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Policy.Migrations
{
    /// <inheritdoc />
    public partial class addedNewtablebenefitTypebenefitRule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonetaryLimit",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "VisitLimit",
                table: "Benefits");

            migrationBuilder.AddColumn<string>(
                name: "AlternativeName",
                table: "Plans",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Plans",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Plans",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "Plans",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Plans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "CoveragePercentage",
                table: "Benefits",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldDefaultValue: 1m);

            migrationBuilder.AddColumn<int>(
                name: "BenefitRuleId",
                table: "Benefits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BenefitTypeId",
                table: "Benefits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Benefits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "MemberCoPaymentPercentage",
                table: "Benefits",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 1m);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Benefits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BenefitRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    LimitType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitRule", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BenefitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitType", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(type: "longtext", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_PolicyId",
                table: "Plans",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_BenefitRuleId",
                table: "Benefits",
                column: "BenefitRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Benefits_BenefitTypeId",
                table: "Benefits",
                column: "BenefitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_BenefitRule_BenefitRuleId",
                table: "Benefits",
                column: "BenefitRuleId",
                principalTable: "BenefitRule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Benefits_BenefitType_BenefitTypeId",
                table: "Benefits",
                column: "BenefitTypeId",
                principalTable: "BenefitType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plans_Policy_PolicyId",
                table: "Plans",
                column: "PolicyId",
                principalTable: "Policy",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_BenefitRule_BenefitRuleId",
                table: "Benefits");

            migrationBuilder.DropForeignKey(
                name: "FK_Benefits_BenefitType_BenefitTypeId",
                table: "Benefits");

            migrationBuilder.DropForeignKey(
                name: "FK_Plans_Policy_PolicyId",
                table: "Plans");

            migrationBuilder.DropTable(
                name: "BenefitRule");

            migrationBuilder.DropTable(
                name: "BenefitType");

            migrationBuilder.DropTable(
                name: "Policy");

            migrationBuilder.DropIndex(
                name: "IX_Plans_PolicyId",
                table: "Plans");

            migrationBuilder.DropIndex(
                name: "IX_Benefits_BenefitRuleId",
                table: "Benefits");

            migrationBuilder.DropIndex(
                name: "IX_Benefits_BenefitTypeId",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "AlternativeName",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BenefitRuleId",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "BenefitTypeId",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "MemberCoPaymentPercentage",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Benefits");

            migrationBuilder.AlterColumn<decimal>(
                name: "CoveragePercentage",
                table: "Benefits",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 1m,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<decimal>(
                name: "MonetaryLimit",
                table: "Benefits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: -1m);

            migrationBuilder.AddColumn<int>(
                name: "VisitLimit",
                table: "Benefits",
                type: "int",
                nullable: false,
                defaultValue: -1);
        }
    }
}
