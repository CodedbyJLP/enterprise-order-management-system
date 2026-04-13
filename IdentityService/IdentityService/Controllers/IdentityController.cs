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
        public IdentityController(IUserService usersService) {
            _usersService = usersService;
        
        
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


        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("API working");
        }



    }
}
