using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LumiaEnd.Migrations
{
    public partial class updatePositionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Positions_Positions_PositionId",
                table: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_Positions_PositionId",
                table: "Positions");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Positions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Positions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionId",
                table: "Positions",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Positions_Positions_PositionId",
                table: "Positions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id");
        }
    }
}
