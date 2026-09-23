using InterviewPratice.Models.Request;
using InterviewPratice.Models.RequestDto;

namespace InterviewPratice.Interface
{
    public interface IUserService
    {
        Task<List<Employee>> GetAllUserDeatils();

        Task<Employee> GetAllUserDeatilsByID(int id);

        Task<UserDto> CreateUser(Employee employee);

        Task<UserDto> UpdateUser(UserUpdate employee, int id);
    }
}
