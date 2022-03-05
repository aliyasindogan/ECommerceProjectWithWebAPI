using Core.Entities.Concrete;
using Core.Entities.Enums;
using Core.Utilities.Security.Hash.Sha512;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers", @"dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .IsRequired();

            builder.Property(x => x.PasswordHash)
              .HasColumnName("PasswordHash")
              .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.ProfileImageUrl)
                .HasColumnName("ProfileImageUrl")
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(x => x.GsmNumber)
              .HasColumnName("GsmNumber")
              .HasMaxLength(11);

            builder.Property(x => x.UserTypeId)
           .HasColumnName("UserTypeId")
           .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CreatedDate")
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            byte[] passwordHash, passwordSalt;
            Sha512Helper.CreatePasswordHash("12345", out passwordHash, out passwordSalt);
            builder.HasData(new User
            {
                Id = 1,
                FirstName = "Ali Yasin",
                LastName = "Doğan",
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,
                Email = "ali@gmail.com",
                UserName = "aliyasin",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                GsmNumber = String.Empty,
                ProfileImageUrl = String.Empty,
                UserTypeId = (int)AppUserTypes.SystemAdmin,
            });
        }
    }
}