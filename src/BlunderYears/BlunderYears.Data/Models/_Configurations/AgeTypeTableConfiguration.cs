namespace BlunderYears.Data.Models._Configurations
{
    using BlunderYears.Data.Models.Enums;
    using BlunderYears.Data.Models.Photos.Photos;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AgeTypeTableConfiguration : IEntityTypeConfiguration<AgeTypeTable>
    {
        public void Configure(EntityTypeBuilder<AgeTypeTable> builder)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            builder.HasEnumData<AgeTypeTable, AgeType>();
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
