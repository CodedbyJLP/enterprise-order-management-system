using IdentityService.ApplicationService.DTOs;

namespace IdentityService.ApplicationService.Interfaces
{
    public interface IUserService
    {
        bool AuthriseUser(LoginRequestDto loginRequest);
    }
}
