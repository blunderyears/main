namespace BlunderYears.Data.Models.Photos.Photos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Enums;
    using BlunderYears.Data.Models.Photos.Albums;
    using Microsoft.EntityFrameworkCore;

    [Table("Photo")]
    [Index(nameof(ContentHash))]
    public sealed class PhotoTable : IntIdentityEntity
    {
        public required long AlbumId { get; set; }

        public AlbumTable Album { get; set; }

        public required DateTime PhotoDateTime { get; set; }

        public required DateTime UploadedDateTime { get; set; }

        public required int Age { get; set; }

        public required AgeType AgeTypeId { get; set; }

        public AgeTypeTable AgeType { get; set; }

        [Column(TypeName = "char")]
        [StringLength(64)]
        public required string ContentHash { get; set; }

        public IList<PhotoExifTable> ExifData { get; set; } = [];
    }
}
