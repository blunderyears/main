namespace BlunderYears.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;
    using BlunderYears.Data.Models.Enums;

    [Table("FamilyPermissions")]
    public class FamilyPermissionsTable : IdentityEntity<FamilyPermissions>
    {
        [StringLength(11)]
        public string Description { get; set; }
    }
}
