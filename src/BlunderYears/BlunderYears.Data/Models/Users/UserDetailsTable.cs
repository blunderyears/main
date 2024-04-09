namespace BlunderYears.Data.Models.Users
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserDetails")]
    public sealed class UserDetailsTable : BaseUserParentTable
    {
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string? GivenName { get; set; }

        [StringLength(200)]
        public string? FamilyName { get; set; }

        public IList<UserTokenTable> Emails { get; set; } = [];
    }
}
