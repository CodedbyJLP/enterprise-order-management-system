using IdentityService.ApplicationService.DTOs;
using IdentityService.ApplicationService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controller
{
    [Route("api/auth")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUserService _usersService;
        public IdentityController(IUserService usersService)
        {
            _usersService = usersService;


        }



        [HttpPost("register")]
        public IActionResult Register(RegisterDTo registerRequest)
        {
            try
            {
                return Ok(_usersService.RegisterUser(registerRequest));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost("login")]
        public IActionResult Login(LoginRequestDto loginRequest)
        {
            try
            {
                return Ok(_usersService.AuthriseUser(loginRequest));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }



        }


        [HttpGet("forgotpwd")]
        public string ForgotPassword(string email)
        {

            try
            {
                return _usersService.ForgotPassword(email);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet("changepwd")]
        public string ChangePassword(Changepassword changepassword)
        {
            try
            {
                return _usersService.ChangePassword(changepassword);
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}
