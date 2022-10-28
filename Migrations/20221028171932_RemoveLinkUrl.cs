using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThousandWords.Migrations
{
    public partial class RemoveLinkUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Links");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
