namespace BlunderYears.Data.Models.Photos.Albums.SyncServices.Dropbox
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;

    [Table("DropboxRegistration")]
    public sealed class DropboxRegistrationTable : IntIdentityEntity
    {
        [StringLength(500)]
        public required string AccessToken { get; set; }

        [StringLength(300)]
        public required string Folder { get; set; }

        public IList<DropboxFileTable> Files { get; set; } = [];
    }
}
