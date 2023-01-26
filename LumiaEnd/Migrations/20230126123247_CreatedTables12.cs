using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LumiaEnd.Migrations
{
    public partial class CreatedTables12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Teams");
        }
    }
}
