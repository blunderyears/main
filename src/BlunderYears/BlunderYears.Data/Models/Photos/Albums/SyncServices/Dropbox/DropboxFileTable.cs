namespace BlunderYears.Data.Models.Photos.Albums.SyncServices.Dropbox
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Photos.Photos;

    public sealed class DropboxFileTable : IntIdentityEntity
    {
        public required long DropboxRegistrationId { get; set; }

        public DropboxRegistrationTable DropboxRegistration { get; set; }

        [StringLength(50)]
        public required string DropboxId { get; set; }

        [Column(TypeName = "char")]
        [StringLength(64)]
        public required string ContentHash { get; set; }

        [StringLength(255)]
        public required string Name { get; set; }

        [StringLength(1000)]
        public required string Path { get; set; }

        public required long PhotoId { get; set; }

        public PhotoTable Photo { get; set; }
    }
}
