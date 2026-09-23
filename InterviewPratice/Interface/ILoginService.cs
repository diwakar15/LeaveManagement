using InterviewPratice.Models.Request;
using InterviewPratice.Models.Response;

namespace InterviewPratice.Services
{
    public interface ILoginService
    {
        Task<LoginResponse >LoginCheck(LoginRequest loginRequest);

        Task<LoginResponse> RegisterUser(RegiesterEmployee RegiesterEmployee);
    }
}
