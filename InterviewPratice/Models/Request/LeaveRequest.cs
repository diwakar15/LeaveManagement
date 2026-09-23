namespace InterviewPratice.Models.Request
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int employeeId { get; set; }

        public string? LeaveType { get; set; }

        public string? LeaveSummary { get; set; }
        public int? No_of_days { get; set; }
        public int? AvailableLeave { get; set; }

    }
}
