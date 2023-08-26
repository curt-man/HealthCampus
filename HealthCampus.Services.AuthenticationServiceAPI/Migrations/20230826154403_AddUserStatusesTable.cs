using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCampus.Services.AuthenticationServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserStatusesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastTimeOnlineDate",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUsersUserStatuses",
                columns: table => new
                {
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    LastTimeOnlineDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsersUserStatuses", x => new { x.AppUserId, x.UserStatusId });
                    table.ForeignKey(
                        name: "FK_AppUsersUserStatuses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUsersUserStatuses_UserStatuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUsersUserStatuses_UserStatusId",
                table: "AppUsersUserStatuses",
                column: "UserStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsersUserStatuses");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastTimeOnlineDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);
        }
    }
}
