namespace InterviewPratice.Models.Response
{
    public class LeaveType
    {
        public int LeaveTypeID { get; set; }
        public string LeaveTypeName { get; set; }

        public string MaximumDaysAllowed { get; set; }

        public string successMessage { get; set; }

        public string failMessage { get; set; }

        public string approvedMessage { get; set; }

        public string rejectedMessage { get; set; }

       

    }
}
