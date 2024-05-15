using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIArticleSiteTemplateProject.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DevBuild_Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryHashTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SysDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActiveFlag = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_PostStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_PostStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_UserActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_UserActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserHasCommentsVisibleOnProfile = table.Column<bool>(type: "bit", nullable: false),
                    ProfilPhotoUUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_TrashedUrls",
                columns: table => new
                {
                    TrashedUrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrashedLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "DevBuild_Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostShortTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostBody = table.Column<string>(type: "VARCHAR(MAX)", nullable: true),
                    PostSysDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeaderImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalComments = table.Column<int>(type: "int", nullable: true),
                    PageViews = table.Column<int>(type: "int", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Posts", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_DevBuild_Posts_DevBuild_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DevBuild_Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevBuild_Posts_DevBuild_PostStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "DevBuild_PostStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevBuild_RoleClaims_DevBuild_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "DevBuild_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevBuild_UserClaims_DevBuild_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "DevBuild_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_DevBuild_UserLogins_DevBuild_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "DevBuild_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_DevBuild_UserRoles_DevBuild_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "DevBuild_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DevBuild_UserRoles_DevBuild_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "DevBuild_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DevBuild_UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_DevBuild_UserTokens_DevBuild_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "DevBuild_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "DevBuild_Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    ParentCommentId = table.Column<int>(type: "int", nullable: true),
                    CommentBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentSysDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevBuild_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_DevBuild_Comments_DevBuild_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "DevBuild_Comments",
                        principalColumn: "CommentId");
                    table.ForeignKey(
                        name: "FK_DevBuild_Comments_DevBuild_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "DevBuild_Posts",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_ArticleParsed_PostId",
                table: "DevBuild_ArticleParsed",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_Comments_ParentCommentId",
                table: "DevBuild_Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_Comments_PostId",
                table: "DevBuild_Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_Posts_CategoryId",
                table: "DevBuild_Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_Posts_StatusId",
                table: "DevBuild_Posts",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_RoleClaims_RoleId",
                table: "DevBuild_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "DevBuild_Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_TrashedUrls_CategoryId",
                table: "DevBuild_TrashedUrls",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_UserClaims_UserId",
                table: "DevBuild_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_UserLogins_UserId",
                table: "DevBuild_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DevBuild_UserRoles_RoleId",
                table: "DevBuild_UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "DevBuild_Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "DevBuild_Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevBuild_ArticleParsed");

            migrationBuilder.DropTable(
                name: "DevBuild_Comments");

            migrationBuilder.DropTable(
                name: "DevBuild_RoleClaims");

            migrationBuilder.DropTable(
                name: "DevBuild_TrashedUrls");

            migrationBuilder.DropTable(
                name: "DevBuild_UserActivityLogs");

            migrationBuilder.DropTable(
                name: "DevBuild_UserClaims");

            migrationBuilder.DropTable(
                name: "DevBuild_UserLogins");

            migrationBuilder.DropTable(
                name: "DevBuild_UserRoles");

            migrationBuilder.DropTable(
                name: "DevBuild_UserTokens");

            migrationBuilder.DropTable(
                name: "DevBuild_Posts");

            migrationBuilder.DropTable(
                name: "DevBuild_Roles");

            migrationBuilder.DropTable(
                name: "DevBuild_Users");

            migrationBuilder.DropTable(
                name: "DevBuild_Categories");

            migrationBuilder.DropTable(
                name: "DevBuild_PostStatuses");
        }
    }
}
