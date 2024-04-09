namespace BlunderYears.Data.EF
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;

    public class BlunderYearsReadOnlyContext : BlunderYearsContext
    {
        public const string ReadOnlyConnectionStringEnvironmentVariable = "BlunderYearsConnectionString";

        public BlunderYearsReadOnlyContext(DbContextOptions<BlunderYearsContext> options, IConfiguration configuration)
            : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
#pragma warning disable CA1062 // Validate arguments of public methods
            this.Database.SetConnectionString(configuration[ReadOnlyConnectionStringEnvironmentVariable]);
#pragma warning restore CA1062 // Validate arguments of public methods
        }

        public override int SaveChanges() => throw new NotSupportedException("Saving is not supported in this context");

        public override int SaveChanges(bool acceptAllChangesOnSuccess) => throw new NotSupportedException("Saving is not supported in this context");

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) => throw new NotSupportedException("Saving is not supported in this context");

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException("Saving is not supported in this context");
    }
}
