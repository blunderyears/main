namespace BlunderYears.Data.Models.Photos.Photos
{
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    [Table("PhotoExif")]
    [PrimaryKey(nameof(PhotoId), nameof(ExifTypeId))]
    public sealed class PhotoExifTable
    {
        public required long PhotoId { get; set; }

        public PhotoTable Photo { get; set; }

        public required Exif ExifTypeId { get; set; }

        public ExifTypeTable ExifType { get; set; }

        public byte[] Value { get; set; } = [];
    }
}
