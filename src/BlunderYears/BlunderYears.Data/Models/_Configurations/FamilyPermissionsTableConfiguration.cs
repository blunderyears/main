namespace BlunderYears.Data.Models._Configurations
{
    using BlunderYears.Data.Models.Enums;
    using BlunderYears.Data.Models.Users;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FamilyPermissionsTableConfiguration : IEntityTypeConfiguration<FamilyPermissionsTable>
    {
        public void Configure(EntityTypeBuilder<FamilyPermissionsTable> builder)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            builder.HasEnumData<FamilyPermissionsTable, FamilyPermissions>();
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
