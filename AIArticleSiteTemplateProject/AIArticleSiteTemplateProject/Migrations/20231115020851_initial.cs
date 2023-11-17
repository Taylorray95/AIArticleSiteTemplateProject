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
            migrationBuilder.DropForeignKey(
                name: "FK_Testing_RoleClaims_Testing_Roles_RoleId",
                table: "Testing_RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Testing_UserClaims_Testing_Users_UserId",
                table: "Testing_UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_Testing_UserLogins_Testing_Users_UserId",
                table: "Testing_UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_Testing_UserRoles_Testing_Roles_RoleId",
                table: "Testing_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Testing_UserRoles_Testing_Users_UserId",
                table: "Testing_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_Testing_UserTokens_Testing_Users_UserId",
                table: "Testing_UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testing_UserTokens",
                table: "Testing_UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testing_Users",
                table: "Testing_Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testing_UserRoles",
                table: "Testing_UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testing_UserLogins",
                table: "Testing_UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testing_UserClaims",
                table: "Testing_UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testing_Roles",
                table: "Testing_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Testing_RoleClaims",
                table: "Testing_RoleClaims");

            migrationBuilder.RenameTable(
                name: "Testing_UserTokens",
                newName: "DevBuild_UserTokens");

            migrationBuilder.RenameTable(
                name: "Testing_Users",
                newName: "DevBuild_Users");

            migrationBuilder.RenameTable(
                name: "Testing_UserRoles",
                newName: "DevBuild_UserRoles");

            migrationBuilder.RenameTable(
                name: "Testing_UserLogins",
                newName: "DevBuild_UserLogins");

            migrationBuilder.RenameTable(
                name: "Testing_UserClaims",
                newName: "DevBuild_UserClaims");

            migrationBuilder.RenameTable(
                name: "Testing_Roles",
                newName: "DevBuild_Roles");

            migrationBuilder.RenameTable(
                name: "Testing_RoleClaims",
                newName: "DevBuild_RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_Testing_UserRoles_RoleId",
                table: "DevBuild_UserRoles",
                newName: "IX_DevBuild_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Testing_UserLogins_UserId",
                table: "DevBuild_UserLogins",
                newName: "IX_DevBuild_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Testing_UserClaims_UserId",
                table: "DevBuild_UserClaims",
                newName: "IX_DevBuild_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Testing_RoleClaims_RoleId",
                table: "DevBuild_RoleClaims",
                newName: "IX_DevBuild_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevBuild_UserTokens",
                table: "DevBuild_UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevBuild_Users",
                table: "DevBuild_Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevBuild_UserRoles",
                table: "DevBuild_UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevBuild_UserLogins",
                table: "DevBuild_UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevBuild_UserClaims",
                table: "DevBuild_UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevBuild_Roles",
                table: "DevBuild_Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DevBuild_RoleClaims",
                table: "DevBuild_RoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DevBuild_RoleClaims_DevBuild_Roles_RoleId",
                table: "DevBuild_RoleClaims",
                column: "RoleId",
                principalTable: "DevBuild_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevBuild_UserClaims_DevBuild_Users_UserId",
                table: "DevBuild_UserClaims",
                column: "UserId",
                principalTable: "DevBuild_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevBuild_UserLogins_DevBuild_Users_UserId",
                table: "DevBuild_UserLogins",
                column: "UserId",
                principalTable: "DevBuild_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevBuild_UserRoles_DevBuild_Roles_RoleId",
                table: "DevBuild_UserRoles",
                column: "RoleId",
                principalTable: "DevBuild_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevBuild_UserRoles_DevBuild_Users_UserId",
                table: "DevBuild_UserRoles",
                column: "UserId",
                principalTable: "DevBuild_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DevBuild_UserTokens_DevBuild_Users_UserId",
                table: "DevBuild_UserTokens",
                column: "UserId",
                principalTable: "DevBuild_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevBuild_RoleClaims_DevBuild_Roles_RoleId",
                table: "DevBuild_RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_DevBuild_UserClaims_DevBuild_Users_UserId",
                table: "DevBuild_UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_DevBuild_UserLogins_DevBuild_Users_UserId",
                table: "DevBuild_UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_DevBuild_UserRoles_DevBuild_Roles_RoleId",
                table: "DevBuild_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_DevBuild_UserRoles_DevBuild_Users_UserId",
                table: "DevBuild_UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_DevBuild_UserTokens_DevBuild_Users_UserId",
                table: "DevBuild_UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevBuild_UserTokens",
                table: "DevBuild_UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevBuild_Users",
                table: "DevBuild_Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevBuild_UserRoles",
                table: "DevBuild_UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevBuild_UserLogins",
                table: "DevBuild_UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevBuild_UserClaims",
                table: "DevBuild_UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevBuild_Roles",
                table: "DevBuild_Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DevBuild_RoleClaims",
                table: "DevBuild_RoleClaims");

            migrationBuilder.RenameTable(
                name: "DevBuild_UserTokens",
                newName: "Testing_UserTokens");

            migrationBuilder.RenameTable(
                name: "DevBuild_Users",
                newName: "Testing_Users");

            migrationBuilder.RenameTable(
                name: "DevBuild_UserRoles",
                newName: "Testing_UserRoles");

            migrationBuilder.RenameTable(
                name: "DevBuild_UserLogins",
                newName: "Testing_UserLogins");

            migrationBuilder.RenameTable(
                name: "DevBuild_UserClaims",
                newName: "Testing_UserClaims");

            migrationBuilder.RenameTable(
                name: "DevBuild_Roles",
                newName: "Testing_Roles");

            migrationBuilder.RenameTable(
                name: "DevBuild_RoleClaims",
                newName: "Testing_RoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_DevBuild_UserRoles_RoleId",
                table: "Testing_UserRoles",
                newName: "IX_Testing_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_DevBuild_UserLogins_UserId",
                table: "Testing_UserLogins",
                newName: "IX_Testing_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DevBuild_UserClaims_UserId",
                table: "Testing_UserClaims",
                newName: "IX_Testing_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_DevBuild_RoleClaims_RoleId",
                table: "Testing_RoleClaims",
                newName: "IX_Testing_RoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testing_UserTokens",
                table: "Testing_UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testing_Users",
                table: "Testing_Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testing_UserRoles",
                table: "Testing_UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testing_UserLogins",
                table: "Testing_UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testing_UserClaims",
                table: "Testing_UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testing_Roles",
                table: "Testing_Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Testing_RoleClaims",
                table: "Testing_RoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Testing_RoleClaims_Testing_Roles_RoleId",
                table: "Testing_RoleClaims",
                column: "RoleId",
                principalTable: "Testing_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testing_UserClaims_Testing_Users_UserId",
                table: "Testing_UserClaims",
                column: "UserId",
                principalTable: "Testing_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testing_UserLogins_Testing_Users_UserId",
                table: "Testing_UserLogins",
                column: "UserId",
                principalTable: "Testing_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testing_UserRoles_Testing_Roles_RoleId",
                table: "Testing_UserRoles",
                column: "RoleId",
                principalTable: "Testing_Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testing_UserRoles_Testing_Users_UserId",
                table: "Testing_UserRoles",
                column: "UserId",
                principalTable: "Testing_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Testing_UserTokens_Testing_Users_UserId",
                table: "Testing_UserTokens",
                column: "UserId",
                principalTable: "Testing_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
