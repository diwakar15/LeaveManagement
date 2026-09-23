using InterviewPratice.Interface;
using InterviewPratice.Models.Request;
using InterviewPratice.Models.RequestDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

namespace InterviewPratice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userservice) 
        {
            _userservice = userservice;
        }

        [HttpGet("User")]
        public async  Task<IActionResult> GetAllUser ()
        {
            var UserDetails =await _userservice.GetAllUserDeatils();

            return Ok(UserDetails);
        }

        [HttpGet("User/{id}")]
        public async Task<IActionResult> GetAllUserByID(int id)
        {
            var UserDetails = await _userservice.GetAllUserDeatilsByID(id);

            return Ok(UserDetails);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(Employee employee)
        {
            var UserDetails = await _userservice.CreateUser(employee);

            return Ok(UserDetails);
        }

        [HttpPost("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(UserUpdate employee, int id)
        {
            var UserDetails = await _userservice.UpdateUser(employee,id);

            return Ok(UserDetails);
        }

    }
}
