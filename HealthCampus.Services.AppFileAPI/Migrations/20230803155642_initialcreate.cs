using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthCampus.Services.AppFileAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileContentTypes",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileContentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BlobContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DownloadUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UploadedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UploadedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFiles_FileContentTypes_ContentTypeId",
                        column: x => x.ContentTypeId,
                        principalTable: "FileContentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FileContentTypes",
                columns: new[] { "Id", "Description", "Extension", "MediaType", "SubType" },
                values: new object[,]
                {
                    { (byte)11, "Joint Photographic Experts Group", ".jpg", "image", "jpeg" },
                    { (byte)12, "Joint Photographic Experts Group", ".jpeg", "image", "jpeg" },
                    { (byte)13, "Graphics Interchange Format", ".gif", "image", "gif" },
                    { (byte)14, "Windows Bitmap", ".bmp", "image", "bmp" },
                    { (byte)15, "Tagged Image File Format", ".tiff", "image", "tiff" },
                    { (byte)16, "WebP image format", ".webp", "image", "webp" },
                    { (byte)17, "Scalable Vector Graphics", ".svg", "image", "svg+xml" },
                    { (byte)18, "Windows Icon file format", ".ico", "image", "x-icon" },
                    { (byte)19, "Animated Portable Network Graphics", ".apng", "image", "apng" },
                    { (byte)20, "AV1 Image File Format", ".avif", "image", "avif" },
                    { (byte)21, "High Efficiency Image Format (.HEIC/.HEIF)", ".heif", "image", "heif" },
                    { (byte)22, "High Efficiency Image Format (.HEIC/.HEIF)", ".heic", "image", "heic" },
                    { (byte)23, "Portable Network Graphics", ".png", "image", "png" },
                    { (byte)31, "Microsoft Word", ".doc", "application", "msword" },
                    { (byte)32, "Microsoft Word Open XML document", ".docx", "application", "vnd.openxmlformats-officedocument.wordprocessingml.document" },
                    { (byte)33, "Microsoft Excel Binary File Format", ".xls", "application", "vnd.ms-excel" },
                    { (byte)34, "Microsoft Excel Open XML spreadsheet", ".xlsx", "application", "vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
                    { (byte)35, "Microsoft PowerPoint", ".ppt", "application", "vnd.ms-powerpoint" },
                    { (byte)36, "PowerPoint Open XML presentation", ".pptx", "application", "vnd.openxmlformats-officedocument.presentationml.presentation" },
                    { (byte)37, "Portable Document Format", ".pdf", "application", "pdf" },
                    { (byte)38, "Rich Text Format", ".rtf", "application", "rtf" },
                    { (byte)39, "Compressed ZIP Archive", ".zip", "application", "zip" },
                    { (byte)40, "RAR Archive", ".rar", "application", "x-rar-compressed" },
                    { (byte)41, "7-Zip Archive", ".7z", "application", "x-7z-compressed" },
                    { (byte)51, "Audio Video Interleave", ".avi", "video", "avi" },
                    { (byte)52, "Flash Video", ".flv", "video", "x-flv" },
                    { (byte)53, "Windows Media Video", ".wmv", "video", "x-ms-wmv" },
                    { (byte)54, "QuickTime", ".mov", "video", "quicktime" },
                    { (byte)55, "MPEG", ".mp4", "video", "mp4" },
                    { (byte)56, "Ogg", ".ogg", "video", "ogg" },
                    { (byte)57, "MPEG-4 Part 14 video file format", ".m4v", "video", "x-m4v" },
                    { (byte)58, "Matroska Multimedia Container", ".mkv", "video", "x-matroska" },
                    { (byte)61, "MPEG-1 or MPEG-2 Audio Layer III", ".mp3", "audio", "mpeg" },
                    { (byte)62, "Waveform Audio File Format", ".wav", "audio", "wav" },
                    { (byte)63, "Windows Media Audio", ".wma", "audio", "x-ms-wma" },
                    { (byte)64, "Advanced Audio Codec", ".aac", "audio", "aac" },
                    { (byte)65, "Audio Interchange File Format", ".aiff", "audio", "aiff" },
                    { (byte)71, "Comma-Separated Values", ".csv", "text", "csv" },
                    { (byte)72, "Plain text", ".txt", "text", "plain" },
                    { (byte)73, "HyperText Markup Language", ".html", "text", "html" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppFiles_ContentTypeId",
                table: "AppFiles",
                column: "ContentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFiles");

            migrationBuilder.DropTable(
                name: "FileContentTypes");
        }
    }
}
