namespace BlunderYears.Data.Models.Users
{
    using BlunderYears.Data.Models.Base;

    public abstract class BaseUserParentTable : IntIdentityEntity
    {
        public required long UserId { get; set; }

        public UserTable User { get; set; }
    }
}
