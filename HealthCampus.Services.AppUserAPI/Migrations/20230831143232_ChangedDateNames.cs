using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthCampus.Services.AppUserAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserINN",
                table: "AspNetUsers",
                newName: "TIN");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "AspNetUsers",
                newName: "RegisteredAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "AspNetUsers",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "LastTimeOnlineDate",
                table: "AppUsersUserStatuses",
                newName: "LastTimeOnlineAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TIN",
                table: "AspNetUsers",
                newName: "UserINN");

            migrationBuilder.RenameColumn(
                name: "RegisteredAt",
                table: "AspNetUsers",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "AspNetUsers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "LastTimeOnlineAt",
                table: "AppUsersUserStatuses",
                newName: "LastTimeOnlineDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
