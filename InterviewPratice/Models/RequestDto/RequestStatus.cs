namespace LeaveManagement.Models.RequestDto
{
    public class RequestStatus
    {
        public string @ApproveOrReject { get; set; }
        public int employeeId { get; set; }
        public int No_of_days { get; set; }
        public string RejectedSummary { get; set; }
    }
}
