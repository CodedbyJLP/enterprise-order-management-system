namespace IdentityService.Domain.Entities
{
    public class RefreshTokensEntity
    {

        public string Token { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get;  set; }

        public UsersEntity User { get; set; }
    }
}
