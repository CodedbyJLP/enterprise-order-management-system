namespace IdentityService.Infrastructure.Repositories
{
    public interface IUserRepository
    {



        bool AuthriseUser(string email, string password);
    }
}
