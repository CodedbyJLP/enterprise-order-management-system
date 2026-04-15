using IdentityService.ApplicationService.DTOs;

namespace IdentityService.ApplicationService.Interfaces
{
    public interface IUserService
    {
        bool AuthriseUser(LoginRequestDto loginRequest);
       
        string ForgotPassword(string email);
        string RegisterUser(RegisterDTo registerRequest);

        string ChangePassword(Changepassword changepassword);
    }
}
