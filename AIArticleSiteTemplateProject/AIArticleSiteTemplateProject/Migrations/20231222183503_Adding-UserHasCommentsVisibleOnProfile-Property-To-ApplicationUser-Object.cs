using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIArticleSiteTemplateProject.Migrations
{
    /// <inheritdoc />
    public partial class AddingUserHasCommentsVisibleOnProfilePropertyToApplicationUserObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserHasCommentsVisibleOnProfile",
                table: "DevBuild_Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserHasCommentsVisibleOnProfile",
                table: "DevBuild_Users");
        }
    }
}
