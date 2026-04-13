using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IdentityService.Infrastructure.Mapping
{
    public class RefreshTokensMapping : IEntityTypeConfiguration<RefreshTokensEntity>
    {

        public void Configure(EntityTypeBuilder<RefreshTokensEntity> builder)
        {
            builder.ToTable("RefreshTokens");

			builder.HasKey(a => a.Id);

			builder.Property(a => a.Id).ValueGeneratedOnAdd();

			builder.Property(a => a.UserId)
				.IsRequired();

			builder.Property(a => a.Token)
				.IsRequired()
				.HasMaxLength(256);
			

			builder.HasOne<UsersEntity>()
				.WithMany()
				.HasForeignKey(a => a.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		

		}
    }
}
