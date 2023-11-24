using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIArticleSiteTemplateProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingArticleParsedTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevBuild_ArticleParsed",
                columns: table => new
                {
                    ArticleParsedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParsedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_ArticleParsed", x => x.ArticleParsedId);
                    table.ForeignKey(
                        name: "FK_DevBuild_ArticleParsed_DevBuild_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "DevBuild_Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_ArticleParsed_PostId",
                table: "DevBuild_ArticleParsed",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevBuild_ArticleParsed");
        }
    }
}
