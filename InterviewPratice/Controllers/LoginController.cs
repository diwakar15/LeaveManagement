using InterviewPratice.Data;
using InterviewPratice.Models.Request;
using InterviewPratice.Models.Response;
using InterviewPratice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InterviewPratice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService=loginService;
        }


        //need to use interface and need to check log in user is developer, manager or admin,
        //if  user not exists need to create new user

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var result = await _loginService.LoginCheck(loginRequest);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegiesterEmployee RegiesterEmployee)
        {
            var result = await _loginService.RegisterUser(RegiesterEmployee);

            return Ok(result);
        }



    }
}
