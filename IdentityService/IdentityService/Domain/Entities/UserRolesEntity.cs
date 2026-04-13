namespace IdentityService.Domain.Entities
{
    public class UserRolesEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public UsersEntity User { get; set; }
        public RolesEntity Role { get; set; }
    }
}
