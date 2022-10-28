using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThousandWords.Migrations
{
    public partial class LinkEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "UploadDate",
                table: "Images",
                newName: "Created");

            migrationBuilder.AddColumn<Guid>(
                name: "LinkId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_LinkId",
                table: "Images",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Links_LinkId",
                table: "Images",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Links_LinkId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Images_LinkId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "Images");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Images",
                newName: "UploadDate");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
