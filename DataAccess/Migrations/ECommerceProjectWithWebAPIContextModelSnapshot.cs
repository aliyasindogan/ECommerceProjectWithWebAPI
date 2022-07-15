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
                        },
                        new
                        {
                            Id = 2,
                            Name = "AppUserTypeAppOperationClaim"
                        },
                        new
                        {
                            Id = 3,
                            Name = "AppUserType"
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
                            CreatedDate = new DateTime(2022, 7, 15, 14, 47, 14, 153, DateTimeKind.Local).AddTicks(2127),
                            CreatedUserId = 1,
                            Email = "ali@gmail.com",
                            FirstName = "Ali Yasin",
                            GsmNumber = "",
                            IsDeleted = false,
                            LastName = "Doğan",
                            PasswordHash = new byte[] { 80, 132, 110, 179, 236, 9, 253, 177, 22, 153, 183, 26, 186, 195, 7, 87, 103, 206, 120, 233, 9, 194, 35, 134, 190, 35, 97, 97, 44, 150, 247, 78, 32, 241, 108, 118, 195, 208, 188, 213, 76, 251, 60, 127, 173, 215, 216, 12, 183, 150, 72, 132, 236, 218, 198, 35, 239, 171, 74, 92, 241, 17, 139, 106 },
                            PasswordSalt = new byte[] { 182, 3, 95, 30, 6, 183, 218, 36, 136, 32, 44, 72, 30, 25, 37, 231, 176, 159, 136, 13, 188, 102, 32, 58, 87, 148, 99, 231, 207, 94, 134, 91, 229, 111, 123, 250, 136, 30, 14, 50, 140, 194, 224, 41, 126, 154, 228, 30, 184, 206, 77, 159, 85, 89, 149, 109, 80, 50, 158, 123, 195, 88, 147, 55, 103, 73, 121, 239, 4, 69, 218, 127, 146, 171, 104, 1, 183, 101, 20, 99, 77, 1, 254, 116, 62, 191, 227, 85, 180, 72, 71, 69, 112, 226, 170, 138, 85, 97, 217, 173, 201, 173, 128, 204, 158, 74, 236, 222, 249, 183, 244, 13, 229, 89, 105, 105, 134, 170, 34, 245, 103, 189, 218, 213, 150, 254, 197, 230 },
                            ProfileImageUrl = "",
                            RefreshToken = new Guid("352e2e2f-051d-437e-929f-e489677113ba"),
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

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("AppUserTypeAppOperationClaims", "dbo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            OperationClaimId = 1,
                            Status = "1111",
                            UserTypeId = 1
                        },
                        new
                        {
                            Id = -2,
                            OperationClaimId = 2,
                            Status = "1111",
                            UserTypeId = 1
                        },
                        new
                        {
                            Id = -3,
                            OperationClaimId = 3,
                            Status = "1111",
                            UserTypeId = 1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.AppUserTypeAppOperationClaim", b =>
                {
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
#pragma warning restore 612, 618
        }
    }
}
