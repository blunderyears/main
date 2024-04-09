namespace BlunderYears.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Enums;
    using BlunderYears.Data.Models.Users;
    using Microsoft.EntityFrameworkCore;

    [Table("UserFamilyPermissions")]
    [PrimaryKey(nameof(UserId), nameof(FamilyId))]
    public class UserFamilyPermissionsTable
    {
        public required long UserId { get; set; }

        public UserTable User { get; set; }

        public required long FamilyId { get; set; }

        public FamilyTable Family { get; set; }

        public required FamilyPermissions PermissionsId { get; set; }

        public FamilyPermissionsTable Permissions { get; set; }
    }
}
