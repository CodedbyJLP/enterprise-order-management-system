using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IdentityService.Infrastructure.Mapping
{
    public class UsersMapping : IEntityTypeConfiguration<UsersEntity>
    {
        public void Configure(EntityTypeBuilder<UsersEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.FirstName)
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PasswordHash)
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();


            builder.HasMany(a => a.RefreshTokens)
                .WithOne(a => a.User).IsRequired()
                .HasForeignKey(a => a.UserId);

            builder.HasMany(a => a.UserRolesEntities)
                .WithOne(a => a.User).IsRequired()
                .HasForeignKey(a => a.RoleId);

        }
    }
}
