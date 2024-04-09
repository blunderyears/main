namespace BlunderYears.Data.Models.Users
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserEmail")]
    public sealed class UserEmailTable : BaseUserParentTable
    {
        [StringLength(250)]
        public required string Email { get; set; }
    }
}
