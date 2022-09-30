using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongsPlayer.Infra.Data.Migrations
{
    public partial class UpdatingAlbumTableWithYearColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Year",
                table: "Albums");
        }
    }
}
