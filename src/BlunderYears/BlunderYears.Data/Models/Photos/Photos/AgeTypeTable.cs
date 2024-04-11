namespace BlunderYears.Data.Models.Photos.Photos
{
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Enums;

    [Table("AgeType")]
    public sealed class AgeTypeTable : EnumEntity<AgeType>
    {
    }
}
