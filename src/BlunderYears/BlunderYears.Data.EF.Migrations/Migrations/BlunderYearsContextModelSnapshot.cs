﻿// <auto-generated />
using System;
using BlunderYears.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlunderYears.Data.EF.Migrations.Migrations
{
    [DbContext(typeof(BlunderYearsContext))]
    partial class BlunderYearsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("blunderyears")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Albums.AlbumTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CreatedByUserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("FamilyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("FamilyId");

                    b.ToTable("Album", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Photos.AgeTypeTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("AgeType", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Photos.ExifTypeTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Exif", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Photos.PhotoExifTable", b =>
                {
                    b.Property<long>("PhotoId")
                        .HasColumnType("bigint");

                    b.Property<int>("ExifTypeId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Value")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("PhotoId", "ExifTypeId");

                    b.HasIndex("ExifTypeId");

                    b.ToTable("PhotoExif", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Photos.PhotoTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("AgeTypeId")
                        .HasColumnType("int");

                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("PhotoDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UploadedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgeTypeId");

                    b.HasIndex("AlbumId");

                    b.ToTable("Photo", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.UserFamilyPermissionsTable", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("FamilyId")
                        .HasColumnType("bigint");

                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "FamilyId");

                    b.HasIndex("FamilyId");

                    b.HasIndex("PermissionsId");

                    b.ToTable("UserFamilyPermissions", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.FamilyPermissionsTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.ToTable("FamilyPermissions", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.FamilyTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("UserAlbumPermissions", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserDetailsTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("FamilyName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("GivenName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserEmailTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserEmail", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("FamilyTableId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FamilyTableId");

                    b.ToTable("User", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserTokenTable", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("Expiration")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Idp")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTimeOffset>("IssuedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("Nonce")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("NotBefore")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ObjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Sub")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long?>("UserDetailsTableId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserDetailsTableId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserToken", "blunderyears");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Albums.AlbumTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Users.UserTable", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlunderYears.Data.Models.Users.FamilyTable", "Family")
                        .WithMany("Albums")
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedByUser");

                    b.Navigation("Family");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Photos.PhotoExifTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Photos.Photos.ExifTypeTable", "ExifType")
                        .WithMany()
                        .HasForeignKey("ExifTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlunderYears.Data.Models.Photos.Photos.PhotoTable", "Photo")
                        .WithMany("ExifData")
                        .HasForeignKey("PhotoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExifType");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Photos.PhotoTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Photos.Photos.AgeTypeTable", "AgeType")
                        .WithMany()
                        .HasForeignKey("AgeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlunderYears.Data.Models.Photos.Albums.AlbumTable", "Album")
                        .WithMany("Photos")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgeType");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.UserFamilyPermissionsTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Users.FamilyTable", "Family")
                        .WithMany()
                        .HasForeignKey("FamilyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlunderYears.Data.Models.Users.FamilyPermissionsTable", "Permissions")
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlunderYears.Data.Models.Users.UserTable", "User")
                        .WithMany("Families")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Family");

                    b.Navigation("Permissions");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserDetailsTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Users.UserTable", "User")
                        .WithOne("Details")
                        .HasForeignKey("BlunderYears.Data.Models.Users.UserDetailsTable", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserEmailTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Users.UserTable", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Users.FamilyTable", null)
                        .WithMany("Members")
                        .HasForeignKey("FamilyTableId");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserTokenTable", b =>
                {
                    b.HasOne("BlunderYears.Data.Models.Users.UserDetailsTable", null)
                        .WithMany("Emails")
                        .HasForeignKey("UserDetailsTableId");

                    b.HasOne("BlunderYears.Data.Models.Users.UserTable", "User")
                        .WithOne("Token")
                        .HasForeignKey("BlunderYears.Data.Models.Users.UserTokenTable", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Albums.AlbumTable", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Photos.Photos.PhotoTable", b =>
                {
                    b.Navigation("ExifData");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.FamilyTable", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserDetailsTable", b =>
                {
                    b.Navigation("Emails");
                });

            modelBuilder.Entity("BlunderYears.Data.Models.Users.UserTable", b =>
                {
                    b.Navigation("Details")
                        .IsRequired();

                    b.Navigation("Families");

                    b.Navigation("Token")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
