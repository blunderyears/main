namespace BlunderYears.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Enums;

    [Table("FamilyPermissions")]
    public class FamilyPermissionsTable : EnumEntity<FamilyPermissions>
    {
    }
}
