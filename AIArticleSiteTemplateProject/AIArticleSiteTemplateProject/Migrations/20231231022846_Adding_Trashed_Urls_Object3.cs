using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIArticleSiteTemplateProject.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Trashed_Urls_Object3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevBuild_TrashedUrls",
                columns: table => new
                {
                    TrashedUrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrashedUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_TrashedUrls", x => x.TrashedUrlId);
                    table.ForeignKey(
                        name: "FK_DevBuild_TrashedUrls_DevBuild_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DevBuild_Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_TrashedUrls_CategoryId",
                table: "DevBuild_TrashedUrls",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevBuild_TrashedUrls");
        }
    }
}
