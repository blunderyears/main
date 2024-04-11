namespace BlunderYears.Data.Models._Configurations
{
    using System;
    using System.Linq;
    using BlunderYears.Data.Models.Base;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal static class EnumTableExtensions
    {
        internal static DataBuilder<TEntity> HasEnumData<TEntity, TEnum>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : EnumEntity<TEnum>, new()
            where TEnum : struct, Enum =>
            builder.HasData(Enum.GetValues<TEnum>().Select(e => new TEntity { Id = e, Description = Enum.GetName(e)! }));
    }
}
