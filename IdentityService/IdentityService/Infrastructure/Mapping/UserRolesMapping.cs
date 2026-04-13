using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IdentityService.Infrastructure.Mapping
{
	public class UserRolesMapping : IEntityTypeConfiguration<UserRolesEntity>
	{

		public void Configure(EntityTypeBuilder<UserRolesEntity> builder)
		{
			builder.ToTable("UserRoles");

			builder.HasKey(a => a.Id);

			builder.Property(a => a.Id).ValueGeneratedOnAdd();

			builder.Property(a => a.UserId);
			builder.Property(a => a.RoleId);

			builder.HasOne<UsersEntity>()
				.WithMany()
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne<RolesEntity>()
				.WithMany()
				.HasForeignKey(a => a.RoleId)
				.OnDelete(DeleteBehavior.Cascade);

		}
	}
}
