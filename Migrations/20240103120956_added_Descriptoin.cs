using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Policy.Migrations
{
    /// <inheritdoc />
    public partial class added_Descriptoin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Benefits",
                type: "longtext",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Benefits");
        }
    }
}
