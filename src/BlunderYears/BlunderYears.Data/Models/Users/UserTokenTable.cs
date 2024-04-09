namespace BlunderYears.Data.Models.Users
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("UserToken")]
    public sealed class UserTokenTable : BaseUserParentTable
    {
        public required Guid Sub { get; set; }

        public required Guid Nonce { get; set; }

        [StringLength(200)]
        public required string Idp { get; set; }

        public required Guid ObjectId { get; set; }

        public required DateTimeOffset IssuedAt { get; set; }

        public required DateTimeOffset Expiration { get; set; }

        public required DateTimeOffset NotBefore { get; set; }
    }
}