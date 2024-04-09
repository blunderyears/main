namespace BlunderYears.Data.Models.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using BlunderYears.Data.Models.Base;

    [Table("User")]
    public sealed class UserTable : IntIdentityEntity
    {
        public required UserTokenTable Token { get; set; }

        public required UserDetailsTable Details { get; set; }

        public IList<UserFamilyPermissionsTable> Families { get; set; } = [];
    }
}
