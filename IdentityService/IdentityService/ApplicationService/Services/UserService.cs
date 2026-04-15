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


        public string RegisterUser(RegisterDTo registerRequest)
        {
            _userRepository.RegisterUser(registerRequest);
            return "User registered successfully";
        }

        public string ForgotPassword(string email)
        {
            return _userRepository.ForgotPassword(email);

        }

        public string ChangePassword(Changepassword changepassword)
        {
            return _userRepository.ChangePassword(changepassword);
        }
    }
}
