using IdentityService.ApplicationService.DTOs;
using IdentityService.ApplicationService.Interfaces;
using IdentityService.Infrastructure.Repositories;

namespace IdentityService.ApplicationService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }

        public bool AuthriseUser(LoginRequestDto loginRequest)
        {
            
            _userRepository.AuthriseUser(loginRequest.Email, loginRequest.Password);
             return true;

        }
    }
}
