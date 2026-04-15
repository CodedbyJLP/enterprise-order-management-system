using IdentityService.ApplicationService.DTOs;

namespace IdentityService.Infrastructure.Repositories
{
    public interface IUserRepository
    {



        bool AuthriseUser(string email, string password);
        
        string ForgotPassword(string email);
        string RegisterUser(RegisterDTo registerRequest);

        string ChangePassword(Changepassword changepassword);
    }
}
