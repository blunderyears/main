using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlunderYears.Data.EF.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false),
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                name: "DropboxRegistration",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Folder = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AlbumTableId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropboxRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropboxRegistration_Album_AlbumTableId",
                        column: x => x.AlbumTableId,
                        principalSchema: "blunderyears",
                        principalTable: "Album",
                        principalColumn: "Id");
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
                    AgeTypeId = table.Column<int>(type: "int", nullable: false),
                    ContentHash = table.Column<string>(type: "char(64)", maxLength: 64, nullable: false)
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
                name: "DropboxFileTable",
                schema: "blunderyears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DropboxRegistrationId = table.Column<long>(type: "bigint", nullable: false),
                    DropboxId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContentHash = table.Column<string>(type: "char(64)", maxLength: 64, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PhotoId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropboxFileTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropboxFileTable_DropboxRegistration_DropboxRegistrationId",
                        column: x => x.DropboxRegistrationId,
                        principalSchema: "blunderyears",
                        principalTable: "DropboxRegistration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DropboxFileTable_Photo_PhotoId",
                        column: x => x.PhotoId,
                        principalSchema: "blunderyears",
                        principalTable: "Photo",
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

            migrationBuilder.InsertData(
                schema: "blunderyears",
                table: "AgeType",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Hours" },
                    { 2, "Days" },
                    { 3, "Weeks" },
                    { 4, "Months" },
                    { 5, "Years" }
                });

            migrationBuilder.InsertData(
                schema: "blunderyears",
                table: "Exif",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 0, "PropertyTagGpsVer" },
                    { 1, "PropertyTagGpsLatitudeRef" },
                    { 2, "PropertyTagGpsLatitude" },
                    { 3, "PropertyTagGpsLongitudeRef" },
                    { 4, "PropertyTagGpsLongitude" },
                    { 5, "PropertyTagGpsAltitudeRef" },
                    { 6, "PropertyTagGpsAltitude" },
                    { 7, "PropertyTagGpsGpsTime" },
                    { 8, "PropertyTagGpsGpsSatellites" },
                    { 9, "PropertyTagGpsGpsStatus" },
                    { 10, "PropertyTagGpsGpsMeasureMode" },
                    { 11, "PropertyTagGpsGpsDop" },
                    { 12, "PropertyTagGpsSpeedRef" },
                    { 13, "PropertyTagGpsSpeed" },
                    { 14, "PropertyTagGpsTrackRef" },
                    { 15, "PropertyTagGpsTrack" },
                    { 16, "PropertyTagGpsImgDirRef" },
                    { 17, "PropertyTagGpsImgDir" },
                    { 18, "PropertyTagGpsMapDatum" },
                    { 19, "PropertyTagGpsDestLatRef" },
                    { 20, "PropertyTagGpsDestLat" },
                    { 21, "PropertyTagGpsDestLongRef" },
                    { 22, "PropertyTagGpsDestLong" },
                    { 23, "PropertyTagGpsDestBearRef" },
                    { 24, "PropertyTagGpsDestBear" },
                    { 25, "PropertyTagGpsDestDistRef" },
                    { 26, "PropertyTagGpsDestDist" },
                    { 254, "PropertyTagNewSubfileType" },
                    { 255, "PropertyTagSubfileType" },
                    { 256, "PropertyTagImageWidth" },
                    { 257, "PropertyTagImageHeight" },
                    { 258, "PropertyTagBitsPerSample" },
                    { 259, "PropertyTagCompression" },
                    { 262, "PropertyTagPhotometricInterp" },
                    { 263, "PropertyTagThreshHolding" },
                    { 264, "PropertyTagCellWidth" },
                    { 265, "PropertyTagCellHeight" },
                    { 266, "PropertyTagFillOrder" },
                    { 269, "PropertyTagDocumentName" },
                    { 270, "PropertyTagImageDescription" },
                    { 271, "PropertyTagEquipMake" },
                    { 272, "PropertyTagEquipModel" },
                    { 273, "PropertyTagStripOffsets" },
                    { 274, "PropertyTagOrientation" },
                    { 277, "PropertyTagSamplesPerPixel" },
                    { 278, "PropertyTagRowsPerStrip" },
                    { 279, "PropertyTagStripBytesCount" },
                    { 280, "PropertyTagMinSampleValue" },
                    { 281, "PropertyTagMaxSampleValue" },
                    { 282, "PropertyTagXResolution" },
                    { 283, "PropertyTagYResolution" },
                    { 284, "PropertyTagPlanarConfig" },
                    { 285, "PropertyTagPageName" },
                    { 286, "PropertyTagXPosition" },
                    { 287, "PropertyTagYPosition" },
                    { 288, "PropertyTagFreeOffset" },
                    { 289, "PropertyTagFreeByteCounts" },
                    { 290, "PropertyTagGrayResponseUnit" },
                    { 291, "PropertyTagGrayResponseCurve" },
                    { 292, "PropertyTagT4Option" },
                    { 293, "PropertyTagT6Option" },
                    { 296, "PropertyTagResolutionUnit" },
                    { 297, "PropertyTagPageNumber" },
                    { 301, "PropertyTagTransferFunction" },
                    { 305, "PropertyTagSoftwareUsed" },
                    { 306, "PropertyTagDateTime" },
                    { 315, "PropertyTagArtist" },
                    { 316, "PropertyTagHostComputer" },
                    { 317, "PropertyTagPredictor" },
                    { 318, "PropertyTagWhitePoint" },
                    { 319, "PropertyTagPrimaryChromaticities" },
                    { 320, "PropertyTagColorMap" },
                    { 321, "PropertyTagHalftoneHints" },
                    { 322, "PropertyTagTileWidth" },
                    { 323, "PropertyTagTileLength" },
                    { 324, "PropertyTagTileOffset" },
                    { 325, "PropertyTagTileByteCounts" },
                    { 332, "PropertyTagInkSet" },
                    { 333, "PropertyTagInkNames" },
                    { 334, "PropertyTagNumberOfInks" },
                    { 336, "PropertyTagDotRange" },
                    { 337, "PropertyTagTargetPrinter" },
                    { 338, "PropertyTagExtraSamples" },
                    { 339, "PropertyTagSampleFormat" },
                    { 340, "PropertyTagSMinSampleValue" },
                    { 341, "PropertyTagSMaxSampleValue" },
                    { 342, "PropertyTagTransferRange" },
                    { 512, "PropertyTagJPEGProc" },
                    { 513, "PropertyTagJPEGInterFormat" },
                    { 514, "PropertyTagJPEGInterLength" },
                    { 515, "PropertyTagJPEGRestartInterval" },
                    { 517, "PropertyTagJPEGLosslessPredictors" },
                    { 518, "PropertyTagJPEGPointTransforms" },
                    { 519, "PropertyTagJPEGQTables" },
                    { 520, "PropertyTagJPEGDCTables" },
                    { 521, "PropertyTagJPEGACTables" },
                    { 529, "PropertyTagYCbCrCoefficients" },
                    { 530, "PropertyTagYCbCrSubsampling" },
                    { 531, "PropertyTagYCbCrPositioning" },
                    { 532, "PropertyTagREFBlackWhite" },
                    { 769, "PropertyTagGamma" },
                    { 770, "PropertyTagICCProfileDescriptor" },
                    { 771, "PropertyTagSRGBRenderingIntent" },
                    { 800, "PropertyTagImageTitle" },
                    { 20481, "PropertyTagResolutionXUnit" },
                    { 20482, "PropertyTagResolutionYUnit" },
                    { 20483, "PropertyTagResolutionXLengthUnit" },
                    { 20484, "PropertyTagResolutionYLengthUnit" },
                    { 20485, "PropertyTagPrintFlags" },
                    { 20486, "PropertyTagPrintFlagsVersion" },
                    { 20487, "PropertyTagPrintFlagsCrop" },
                    { 20488, "PropertyTagPrintFlagsBleedWidth" },
                    { 20489, "PropertyTagPrintFlagsBleedWidthScale" },
                    { 20490, "PropertyTagHalftoneLPI" },
                    { 20491, "PropertyTagHalftoneLPIUnit" },
                    { 20492, "PropertyTagHalftoneDegree" },
                    { 20493, "PropertyTagHalftoneShape" },
                    { 20494, "PropertyTagHalftoneMisc" },
                    { 20495, "PropertyTagHalftoneScreen" },
                    { 20496, "PropertyTagJPEGQuality" },
                    { 20497, "PropertyTagGridSize" },
                    { 20498, "PropertyTagThumbnailFormat" },
                    { 20499, "PropertyTagThumbnailWidth" },
                    { 20500, "PropertyTagThumbnailHeight" },
                    { 20501, "PropertyTagThumbnailColorDepth" },
                    { 20502, "PropertyTagThumbnailPlanes" },
                    { 20503, "PropertyTagThumbnailRawBytes" },
                    { 20504, "PropertyTagThumbnailSize" },
                    { 20505, "PropertyTagThumbnailCompressedSize" },
                    { 20506, "PropertyTagColorTransferFunction" },
                    { 20507, "PropertyTagThumbnailData" },
                    { 20512, "PropertyTagThumbnailImageWidth" },
                    { 20513, "PropertyTagThumbnailImageHeight" },
                    { 20514, "PropertyTagThumbnailBitsPerSample" },
                    { 20515, "PropertyTagThumbnailCompression" },
                    { 20516, "PropertyTagThumbnailPhotometricInterp" },
                    { 20517, "PropertyTagThumbnailImageDescription" },
                    { 20518, "PropertyTagThumbnailEquipMake" },
                    { 20519, "PropertyTagThumbnailEquipModel" },
                    { 20520, "PropertyTagThumbnailStripOffsets" },
                    { 20521, "PropertyTagThumbnailOrientation" },
                    { 20522, "PropertyTagThumbnailSamplesPerPixel" },
                    { 20523, "PropertyTagThumbnailRowsPerStrip" },
                    { 20524, "PropertyTagThumbnailStripBytesCount" },
                    { 20525, "PropertyTagThumbnailResolutionX" },
                    { 20526, "PropertyTagThumbnailResolutionY" },
                    { 20527, "PropertyTagThumbnailPlanarConfig" },
                    { 20528, "PropertyTagThumbnailResolutionUnit" },
                    { 20529, "PropertyTagThumbnailTransferFunction" },
                    { 20530, "PropertyTagThumbnailSoftwareUsed" },
                    { 20531, "PropertyTagThumbnailDateTime" },
                    { 20532, "PropertyTagThumbnailArtist" },
                    { 20533, "PropertyTagThumbnailWhitePoint" },
                    { 20534, "PropertyTagThumbnailPrimaryChromaticities" },
                    { 20535, "PropertyTagThumbnailYCbCrCoefficients" },
                    { 20536, "PropertyTagThumbnailYCbCrSubsampling" },
                    { 20537, "PropertyTagThumbnailYCbCrPositioning" },
                    { 20538, "PropertyTagThumbnailRefBlackWhite" },
                    { 20539, "PropertyTagThumbnailCopyRight" },
                    { 20624, "PropertyTagLuminanceTable" },
                    { 20625, "PropertyTagChrominanceTable" },
                    { 20736, "PropertyTagFrameDelay" },
                    { 20737, "PropertyTagLoopCount" },
                    { 20738, "PropertyTagGlobalPalette" },
                    { 20739, "PropertyTagIndexBackground" },
                    { 20740, "PropertyTagIndexTransparent" },
                    { 20752, "PropertyTagPixelUnit" },
                    { 20753, "PropertyTagPixelPerUnitX" },
                    { 20754, "PropertyTagPixelPerUnitY" },
                    { 20755, "PropertyTagPaletteHistogram" },
                    { 33432, "PropertyTagCopyright" },
                    { 33434, "PropertyTagExifExposureTime" },
                    { 33437, "PropertyTagExifFNumber" },
                    { 34665, "PropertyTagExifIFD" },
                    { 34675, "PropertyTagICCProfile" },
                    { 34850, "PropertyTagExifExposureProg" },
                    { 34852, "PropertyTagExifSpectralSense" },
                    { 34853, "PropertyTagGpsIFD" },
                    { 34855, "PropertyTagExifISOSpeed" },
                    { 34856, "PropertyTagExifOECF" },
                    { 36864, "PropertyTagExifVer" },
                    { 36867, "PropertyTagExifDTOrig" },
                    { 36868, "PropertyTagExifDTDigitized" },
                    { 37121, "PropertyTagExifCompConfig" },
                    { 37122, "PropertyTagExifCompBPP" },
                    { 37377, "PropertyTagExifShutterSpeed" },
                    { 37378, "PropertyTagExifAperture" },
                    { 37379, "PropertyTagExifBrightness" },
                    { 37380, "PropertyTagExifExposureBias" },
                    { 37381, "PropertyTagExifMaxAperture" },
                    { 37382, "PropertyTagExifSubjectDist" },
                    { 37383, "PropertyTagExifMeteringMode" },
                    { 37384, "PropertyTagExifLightSource" },
                    { 37385, "PropertyTagExifFlash" },
                    { 37386, "PropertyTagExifFocalLength" },
                    { 37500, "PropertyTagExifMakerNote" },
                    { 37510, "PropertyTagExifUserComment" },
                    { 37520, "PropertyTagExifDTSubsec" },
                    { 37521, "PropertyTagExifDTOrigSS" },
                    { 37522, "PropertyTagExifDTDigSS" },
                    { 40960, "PropertyTagExifFPXVer" },
                    { 40961, "PropertyTagExifColorSpace" },
                    { 40962, "PropertyTagExifPixXDim" },
                    { 40963, "PropertyTagExifPixYDim" },
                    { 40964, "PropertyTagExifRelatedWav" },
                    { 40965, "PropertyTagExifInterop" },
                    { 41483, "PropertyTagExifFlashEnergy" },
                    { 41484, "PropertyTagExifSpatialFR" },
                    { 41486, "PropertyTagExifFocalXRes" },
                    { 41487, "PropertyTagExifFocalYRes" },
                    { 41488, "PropertyTagExifFocalResUnit" },
                    { 41492, "PropertyTagExifSubjectLoc" },
                    { 41493, "PropertyTagExifExposureIndex" },
                    { 41495, "PropertyTagExifSensingMethod" },
                    { 41728, "PropertyTagExifFileSource" },
                    { 41729, "PropertyTagExifSceneType" },
                    { 41730, "PropertyTagExifCfaPattern" }
                });

            migrationBuilder.InsertData(
                schema: "blunderyears",
                table: "FamilyPermissions",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Owner" },
                    { 2, "Partner" },
                    { 3, "Contributor" },
                    { 4, "Reader" }
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
                name: "IX_DropboxFileTable_DropboxRegistrationId",
                schema: "blunderyears",
                table: "DropboxFileTable",
                column: "DropboxRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_DropboxFileTable_PhotoId",
                schema: "blunderyears",
                table: "DropboxFileTable",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_DropboxRegistration_AlbumTableId",
                schema: "blunderyears",
                table: "DropboxRegistration",
                column: "AlbumTableId");

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
                name: "IX_Photo_ContentHash",
                schema: "blunderyears",
                table: "Photo",
                column: "ContentHash");

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
                name: "DropboxFileTable",
                schema: "blunderyears");

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
                name: "DropboxRegistration",
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
