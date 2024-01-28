using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Policy.Migrations
{
    /// <inheritdoc />
    public partial class addedPolicyName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Policies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Plans");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BenefitTypes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "BenefitRules");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Policies",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Policies");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Policies",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Plans",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Categories",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BenefitTypes",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Benefits",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "BenefitRules",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
