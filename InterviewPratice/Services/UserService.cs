using Azure.Core;
using InterviewPratice.Data;
using InterviewPratice.Interface;
using InterviewPratice.Models.Request;
using InterviewPratice.Models.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace InterviewPratice.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext=applicationDbContext;
        }


        public async Task<List<Employee>> GetAllUserDeatils()
        {
            var UserDetails = await _applicationDbContext.Employees.FromSqlRaw("SP_UserDetails").ToListAsync();

            return UserDetails;

        }
        public async Task<Employee> GetAllUserDeatilsByID(int id)
        {
            var UserDetails = await _applicationDbContext.Employees.FromSqlRaw($"SP_UserDetailsById {id}").ToListAsync();

            return UserDetails.FirstOrDefault();

        }

        public async Task<UserDto> CreateUser(Employee employee)
        {
            var response = await _applicationDbContext.Database.ExecuteSqlRawAsync("Exec SP_CreateUser @employeeName, @email, @age, @Department, @Password",
        new[] {
            new SqlParameter("@employeeName", employee.employeeName),
            new SqlParameter("@email", employee.Email),
            new SqlParameter("@age", employee.age),
            new SqlParameter("@Department", employee.Department),
            new SqlParameter("@Password", employee.Password)
        });

            //Below also works
            //  var response = await _applicationDbContext.Database.ExecuteSqlInterpolatedAsync($""" EXEC SP_CreateUser @employeeName={employee.employeeName},@Age={employee.age},@Email={employee.Email},@Department={employee.Department},@Password={employee.Password}""");
            UserDto User = new UserDto();

            //User.employeeName = employee.employeeName ;



            return new UserDto {
                employeeName = employee.employeeName,
                UserCreation = response.ToString()
            };

        }

        public async Task<UserDto> UpdateUser(UserUpdate employee, int id)
        {
            int employeeid = id;
            var response = await _applicationDbContext.Database.ExecuteSqlInterpolatedAsync($""" EXEC SP_UpdateUser @employeeid={employeeid},@employeeName={employee.employeeName},@Age={employee.age},@Email={employee.Email}""");

            UserDto User = new UserDto();

            //User.employeeName = employee.employeeName ;



            return new UserDto
            {
                employeeName = employee.employeeName,
                UpdateMessage = response.ToString()
            };

        }
    }
}
