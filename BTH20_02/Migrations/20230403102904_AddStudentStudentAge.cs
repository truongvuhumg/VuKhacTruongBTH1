using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTH20_02.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentStudentAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "StudentAge",
                table: "Students",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentAge",
                table: "Students");
        }
    }
}
