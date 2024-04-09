namespace BlunderYears.Data.EF
{
    using System;
    using System.Diagnostics;
    using BlunderYears.Data.Models;
    using BlunderYears.Data.Models.Photos.Albums;
    using BlunderYears.Data.Models.Photos.Photos;
    using BlunderYears.Data.Models.Users;
    using Microsoft.EntityFrameworkCore;

    public class BlunderYearsContext : DbContext
    {
        public BlunderYearsContext(DbContextOptions<BlunderYearsContext> options)
            : base(options)
        {
        }

        public DbSet<AlbumTable> Albums { get; set; }

        public DbSet<AgeTypeTable> AgeTypes { get; set; }

        public DbSet<ExifTypeTable> ExifTypes { get; set; }

        public DbSet<PhotoExifTable> PhotoExifs { get; set; }

        public DbSet<PhotoTable> Photos { get; set; }

        public DbSet<FamilyPermissionsTable> FamilyPermissions { get; set; }

        public DbSet<FamilyTable> Families { get; set; }

        public DbSet<UserDetailsTable> UserDetails { get; set; }

        public DbSet<UserEmailTable> UserEmails { get; set; }

        public DbSet<UserFamilyPermissionsTable> UserFamilyPermissions { get; set; }

        public DbSet<UserTable> Users { get; set; }

        public DbSet<UserTokenTable> UserTokens { get; set; }

        internal static string Schema { get; } = "blunderyears";

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(BlunderYearsContext.Schema);

#pragma warning disable CA1062 // Validate arguments of public methods
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Activity).Assembly);
#pragma warning restore CA1062 // Validate arguments of public methods
        }
    }
}
