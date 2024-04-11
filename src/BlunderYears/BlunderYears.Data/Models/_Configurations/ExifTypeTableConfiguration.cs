namespace BlunderYears.Data.Models._Configurations
{
    using BlunderYears.Data.Models.Enums;
    using BlunderYears.Data.Models.Photos.Photos;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ExifTypeTableConfiguration : IEntityTypeConfiguration<ExifTypeTable>
    {
        public void Configure(EntityTypeBuilder<ExifTypeTable> builder)
        {
#pragma warning disable CA1062 // Validate arguments of public methods
            builder.HasEnumData<ExifTypeTable, Exif>();
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
