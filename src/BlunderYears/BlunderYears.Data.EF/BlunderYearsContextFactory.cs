namespace BlunderYears.Data.EF
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public sealed class BlunderYearsContextFactory : IDesignTimeDbContextFactory<BlunderYearsContext>
    {
        public BlunderYearsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BlunderYearsContext>()
                .UseSqlServer(
                    args is { Length: 1 } ? args[0] : Environment.GetEnvironmentVariable("BlunderYearsConnectionString"),
                    opts => opts.MigrationsHistoryTable("__EFMigrationsHistory", BlunderYearsContext.Schema)
                                .MigrationsAssembly("BlunderYears.Data.EF.Migrations"));

            return new(optionsBuilder.Options);
        }
    }
}
