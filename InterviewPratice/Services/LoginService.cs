using Azure.Core;
using InterviewPratice.Data;
using InterviewPratice.Models.Request;
using InterviewPratice.Models.Response;
using InterviewPratice.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InterviewPratice.BussinessLogic
{
    public class LoginService : ILoginService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public LoginService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext=applicationDbContext;
        }

        public async Task<LoginResponse>  LoginCheck(LoginRequest loginRequest) 
        {
            if (loginRequest == null)
            {
                return null;
            }

            var Loginresponse = await _applicationDbContext.Employees.FirstOrDefaultAsync(e => e.Email == loginRequest.Email);

            if (Loginresponse == null)
            {
                return null;
            }
            if (loginRequest.Password != Loginresponse.Password)
            {
                return null;
            }
            return new LoginResponse
            {
                EmployeeId = Loginresponse.employeeId,
            };
        }

        public async Task<LoginResponse> RegisterUser(RegiesterEmployee employee)
        {
            if (employee == null) { return null; }

            var response = await _applicationDbContext.Database.ExecuteSqlRawAsync(
        "Exec SP_RegisterUser @employeeName, @email, @age, @password",
        new[] {
            new SqlParameter("@employeeName", employee.employeeName),
            new SqlParameter("@email", employee.Email),
            new SqlParameter("@age", employee.age),
            new SqlParameter("@password", employee.Password)
        });

            var Message = response.ToString();

            if (response == 0)
            {
                Message = "Failed";
            }
            else
            {
                Message = "Passed";

            }

            return new LoginResponse
            {
                RegiesterMessage = Message
            };

        }
    }
}
