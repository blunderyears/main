namespace BlunderYears.Data.Models.Photos.Albums
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Photos.Albums.SyncServices.Dropbox;
    using BlunderYears.Data.Models.Photos.Photos;
    using BlunderYears.Data.Models.Users;

    [Table("Album")]
    public sealed class AlbumTable : IntIdentityEntity
    {
        public required long FamilyId { get; set; }

        public FamilyTable Family { get; set; }

        public required long CreatedByUserId { get; set; }

        public UserTable CreatedByUser { get; set; }

        public required DateTime CreatedDateTime { get; set; }

        [StringLength(200)]
        public required string Name { get; set; }

        public IList<PhotoTable> Photos { get; set; } = [];

        public IList<DropboxRegistrationTable> DropboxRegistrations { get; set; } = [];
    }
}
