namespace InterviewPratice.Models.Response
{
    public class LoginResponse
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        public string RegiesterMessage { get; set; } = string.Empty;
    }
}
