using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthCampus.Services.AppFileAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)11);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)12);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)13);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)14);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)15);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)16);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)17);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)18);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)19);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)20);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)21);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)22);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)23);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)31);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)32);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)33);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)34);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)35);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)36);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)37);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)38);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)39);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)40);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)41);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)51);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)52);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)53);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)54);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)55);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)56);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)57);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)58);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)61);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)62);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)63);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)64);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)65);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)71);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)72);

            migrationBuilder.DeleteData(
                table: "FileContentTypes",
                keyColumn: "Id",
                keyValue: (byte)73);

            migrationBuilder.RenameColumn(
                name: "UploadedDate",
                table: "AppFiles",
                newName: "UploadedAt");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "AppFiles",
                newName: "ModifiedAt");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalName",
                table: "AppFiles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BlobContainer",
                table: "AppFiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UploadedAt",
                table: "AppFiles",
                newName: "UploadedDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "AppFiles",
                newName: "ModifiedDate");

            migrationBuilder.AlterColumn<string>(
                name: "OriginalName",
                table: "AppFiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "BlobContainer",
                table: "AppFiles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
        }
    }
}
