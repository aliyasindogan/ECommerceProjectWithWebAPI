﻿// <auto-generated />
using System;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ECommerceDbContext))]
    partial class ECommerceProjectWithWebAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Concrete.AppOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("AppOperationClaims", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "AppUser"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeletedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("GsmNumber")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("GsmNumber");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("ProfileImageUrl")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("ProfileImageUrl");

                    b.Property<Guid>("RefreshToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeId");

                    b.HasKey("Id");

                    b.ToTable("AppUsers", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 3, 25, 23, 8, 13, 960, DateTimeKind.Local).AddTicks(4912),
                            CreatedUserId = 1,
                            Email = "ali@gmail.com",
                            FirstName = "Ali Yasin",
                            GsmNumber = "",
                            IsDeleted = false,
                            LastName = "Doğan",
                            PasswordHash = new byte[] { 2, 42, 139, 34, 254, 191, 85, 175, 99, 175, 5, 104, 21, 179, 125, 97, 248, 136, 228, 52, 30, 172, 134, 242, 73, 93, 143, 242, 114, 204, 206, 202, 197, 223, 248, 181, 139, 178, 99, 197, 136, 77, 113, 75, 138, 234, 109, 131, 37, 27, 3, 83, 208, 95, 58, 192, 151, 15, 8, 41, 44, 226, 29, 101 },
                            PasswordSalt = new byte[] { 244, 183, 176, 211, 117, 75, 181, 109, 2, 213, 84, 57, 107, 21, 17, 56, 76, 207, 91, 97, 250, 138, 253, 181, 21, 244, 173, 246, 123, 184, 69, 24, 67, 179, 36, 103, 173, 100, 240, 73, 17, 26, 114, 123, 172, 97, 170, 110, 215, 46, 153, 79, 138, 94, 209, 127, 90, 26, 35, 28, 236, 14, 145, 202, 177, 31, 115, 81, 106, 141, 6, 238, 208, 195, 172, 149, 17, 188, 50, 33, 2, 0, 166, 43, 176, 120, 23, 25, 184, 231, 158, 187, 247, 131, 124, 0, 236, 109, 184, 15, 6, 101, 129, 241, 5, 45, 6, 36, 230, 7, 95, 21, 27, 254, 237, 181, 89, 115, 8, 199, 103, 114, 236, 90, 67, 220, 86, 233 },
                            ProfileImageUrl = "",
                            RefreshToken = new Guid("b4489d7f-739a-435f-a645-95ec5aa7739c"),
                            UserName = "aliyasin",
                            UserTypeId = 1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.AppUserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserTypeName");

                    b.HasKey("Id");

                    b.ToTable("AppUserTypes", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserTypeName = "System Admin"
                        },
                        new
                        {
                            Id = 2,
                            UserTypeName = "Admin"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.AppUserTypeAppOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppUserId")
                        .HasColumnType("int");

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int")
                        .HasColumnName("OperationClaimId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("char(4)")
                        .HasColumnName("Status");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeId");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("AppUserTypeAppOperationClaims", "dbo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            OperationClaimId = 1,
                            Status = "1111",
                            UserTypeId = 2
                        });
                });

            modelBuilder.Entity("Entities.Concrete.AppUserTypeAppOperationClaim", b =>
                {
                    b.HasOne("Entities.Concrete.AppUser", null)
                        .WithMany("AppUserTypeAppOperationClaims")
                        .HasForeignKey("AppUserId");

                    b.HasOne("Entities.Concrete.AppOperationClaim", "AppOperationClaim")
                        .WithMany("AppUserTypeAppOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.AppUserType", "AppUserType")
                        .WithMany()
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppOperationClaim");

                    b.Navigation("AppUserType");
                });

            modelBuilder.Entity("Entities.Concrete.AppOperationClaim", b =>
                {
                    b.Navigation("AppUserTypeAppOperationClaims");
                });

            modelBuilder.Entity("Entities.Concrete.AppUser", b =>
                {
                    b.Navigation("AppUserTypeAppOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
