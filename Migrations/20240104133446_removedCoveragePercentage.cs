using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Policy.Migrations
{
    /// <inheritdoc />
    public partial class removedCoveragePercentage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoveragePercentage",
                table: "Benefits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CoveragePercentage",
                table: "Benefits",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
