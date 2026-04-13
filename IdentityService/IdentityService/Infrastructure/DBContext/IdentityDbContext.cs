using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace IdentityService.Infrastructure.DBContext
{
    public class IdentityDbContext : DbContext
    {

        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<RolesEntity> Roles { get; set; }
        public DbSet<RefreshTokensEntity> RefreshTokens { get; set; }

        public DbSet<UserRolesEntity> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all mapping configurations automatically
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);

        }
    }
}
