namespace IdentityService.ApplicationService.DTOs
{
    public class RegisterDTo
    {

        public string? FirstName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? LastName { get; set; }

    }
}
