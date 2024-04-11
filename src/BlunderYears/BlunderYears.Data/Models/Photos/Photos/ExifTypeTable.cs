namespace BlunderYears.Data.Models.Photos.Photos
{
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Enums;

    [Table("Exif")]
    public sealed class ExifTypeTable : EnumEntity<Exif>
    {
    }
}
