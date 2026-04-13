namespace IdentityService.Domain.Entities
{
    public class UsersEntity
    {

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public ICollection<RefreshTokensEntity> RefreshTokens { get; set; }
        public ICollection<UserRolesEntity> UserRolesEntities { get; set; }


    }
}
