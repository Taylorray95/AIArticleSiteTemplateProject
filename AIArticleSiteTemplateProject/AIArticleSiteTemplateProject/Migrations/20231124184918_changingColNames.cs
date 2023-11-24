using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIArticleSiteTemplateProject.Migrations
{
    /// <inheritdoc />
    public partial class changingColNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PathToImage4",
                table: "DevBuild_Posts",
                newName: "Image4");

            migrationBuilder.RenameColumn(
                name: "PathToImage3",
                table: "DevBuild_Posts",
                newName: "Image3");

            migrationBuilder.RenameColumn(
                name: "PathToHeaderImage",
                table: "DevBuild_Posts",
                newName: "HeaderImage");

            migrationBuilder.RenameColumn(
                name: "PathToBodyImage",
                table: "DevBuild_Posts",
                newName: "BodyImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image4",
                table: "DevBuild_Posts",
                newName: "PathToImage4");

            migrationBuilder.RenameColumn(
                name: "Image3",
                table: "DevBuild_Posts",
                newName: "PathToImage3");

            migrationBuilder.RenameColumn(
                name: "HeaderImage",
                table: "DevBuild_Posts",
                newName: "PathToHeaderImage");

            migrationBuilder.RenameColumn(
                name: "BodyImage",
                table: "DevBuild_Posts",
                newName: "PathToBodyImage");
        }
    }
}
