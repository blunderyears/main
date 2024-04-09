namespace BlunderYears.Data.Models.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Photos.Albums;

    [Table("UserAlbumPermissions")]
    public sealed class FamilyTable : IntIdentityEntity
    {
        [StringLength(200)]
        public required string Name { get; set; }

        public IList<UserTable> Members { get; set; } = [];

        public IList<AlbumTable> Albums { get; set; } = [];
    }
}
