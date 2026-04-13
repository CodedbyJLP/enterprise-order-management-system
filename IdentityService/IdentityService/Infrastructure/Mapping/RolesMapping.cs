using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IdentityService.Infrastructure.Mapping
{
    public class RolesMapping : IEntityTypeConfiguration<RolesEntity>
    {
        public void Configure(EntityTypeBuilder<RolesEntity> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(a => a.Id);

            builder.Property(a=>a.Id).ValueGeneratedOnAdd();

			builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);


            builder.HasMany<UserRolesEntity>()
                .WithOne(a => a.Role)
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

        }

    }
}
