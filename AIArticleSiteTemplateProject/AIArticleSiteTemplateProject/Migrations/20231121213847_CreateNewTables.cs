using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIArticleSiteTemplateProject.Migrations
{
    public partial class CreateNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevBuild_Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryDesc = table.Column<string>(nullable: true),
                    SysDate = table.Column<DateTime>(nullable: false),
                    CategoryHashTag = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    CommentBody = table.Column<string>(nullable: true),
                    CommentSysDate = table.Column<DateTime>(nullable: false),
                    CommentLastUpdated = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ParentCommentId = table.Column<int>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Comments", x => x.CommentId);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostShortTitle = table.Column<string>(nullable: true),
                    PostTitle = table.Column<string>(nullable: true),
                    PostBody = table.Column<string>(nullable: true),
                    PostCategoryId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    PostSysDate = table.Column<DateTime>(nullable: true),
                    PostLastUpdated = table.Column<DateTime>(nullable: true),
                    PathToBodyImage = table.Column<string>(nullable: true),
                    PathToHeaderImage = table.Column<string>(nullable: true),
                    PageViews = table.Column<int>(nullable: false),
                    TotalComments = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    PathToImage3 = table.Column<string>(nullable: true),
                    PathToImage4 = table.Column<string>(nullable: true),
                    Article_Parsed_Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_PostStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: true),
                    StatusDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_PostStatuses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevBuild_Categories");
            migrationBuilder.DropTable(
                name: "DevBuild_Comments");
            migrationBuilder.DropTable(
                name: "DevBuild_Posts");
            migrationBuilder.DropTable(
                name: "DevBuild_PostStatuses");
        }
    }
}
