using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlunderYears.Data.EF.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blunderyears");

            migrationBuilder.CreateTable(
                name: "AgeType",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exif",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exif", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyPermissions",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAlbumPermissions",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAlbumPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyTableId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_UserAlbumPermissions_FamilyTableId",
                        column: x => x.FamilyTableId,
                        principalSchema: "blunderyears",
                        principalTable: "UserAlbumPermissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Album",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_UserAlbumPermissions_FamilyId",
                        column: x => x.FamilyId,
                        principalSchema: "blunderyears",
                        principalTable: "UserAlbumPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Album_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "blunderyears",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GivenName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FamilyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "blunderyears",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEmail",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEmail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEmail_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "blunderyears",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFamilyPermissions",
                schema: "blunderyears",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    FamilyId = table.Column<long>(type: "bigint", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFamilyPermissions", x => new { x.UserId, x.FamilyId });
                    table.ForeignKey(
                        name: "FK_UserFamilyPermissions_FamilyPermissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalSchema: "blunderyears",
                        principalTable: "FamilyPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFamilyPermissions_UserAlbumPermissions_FamilyId",
                        column: x => x.FamilyId,
                        principalSchema: "blunderyears",
                        principalTable: "UserAlbumPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFamilyPermissions_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "blunderyears",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumId = table.Column<long>(type: "bigint", nullable: false),
                    PhotoDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UploadedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    AgeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_AgeType_AgeTypeId",
                        column: x => x.AgeTypeId,
                        principalSchema: "blunderyears",
                        principalTable: "AgeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Photo_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "blunderyears",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sub = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nonce = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Idp = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ObjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssuedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Expiration = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    NotBefore = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserDetailsTableId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToken_UserDetails_UserDetailsTableId",
                        column: x => x.UserDetailsTableId,
                        principalSchema: "blunderyears",
                        principalTable: "UserDetails",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "blunderyears",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoExif",
                schema: "blunderyears",
                columns: table => new
                {
                    PhotoId = table.Column<long>(type: "bigint", nullable: false),
                    ExifTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoExif", x => new { x.PhotoId, x.ExifTypeId });
                    table.ForeignKey(
                        name: "FK_PhotoExif_Exif_ExifTypeId",
                        column: x => x.ExifTypeId,
                        principalSchema: "blunderyears",
                        principalTable: "Exif",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoExif_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "blunderyears",
                        principalTable: "Photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_CreatedByUserId",
                schema: "blunderyears",
                table: "Album",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_FamilyId",
                schema: "blunderyears",
                table: "Album",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AgeTypeId",
                schema: "blunderyears",
                table: "Photo",
                column: "AgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AlbumId",
                schema: "blunderyears",
                table: "Photo",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoExif_ExifTypeId",
                schema: "blunderyears",
                table: "PhotoExif",
                column: "ExifTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_FamilyTableId",
                schema: "blunderyears",
                table: "User",
                column: "FamilyTableId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                schema: "blunderyears",
                table: "UserDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserEmail_UserId",
                schema: "blunderyears",
                table: "UserEmail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFamilyPermissions_FamilyId",
                schema: "blunderyears",
                table: "UserFamilyPermissions",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFamilyPermissions_PermissionsId",
                schema: "blunderyears",
                table: "UserFamilyPermissions",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserDetailsTableId",
                schema: "blunderyears",
                table: "UserToken",
                column: "UserDetailsTableId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToken_UserId",
                schema: "blunderyears",
                table: "UserToken",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhotoExif",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "UserEmail",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "UserFamilyPermissions",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "UserToken",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "Exif",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "Photo",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "FamilyPermissions",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "UserDetails",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "AgeType",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "Album",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "User",
                schema: "blunderyears");

            migrationBuilder.DropTable(
                name: "UserAlbumPermissions",
                schema: "blunderyears");
        }
    }
}
