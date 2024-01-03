using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIArticleSiteTemplateProject.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Trashed_Urls_Object4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrashedUrl",
                table: "DevBuild_TrashedUrls",
                newName: "TrashedLink");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TrashedLink",
                table: "DevBuild_TrashedUrls",
                newName: "TrashedUrl");
        }
    }
}
