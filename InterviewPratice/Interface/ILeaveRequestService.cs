using InterviewPratice.Models.Request;
using InterviewPratice.Models.RequestDto;
using LeaveManagement.Models.RequestDto;

namespace InterviewPratice.Interface
{
    public interface ILeaveRequestService
    {
        List<LeaveRequest> GetLeaveRequestDetails();

        LeaveRequest GetLeaveRequestDetailsByID(int id);

        Task<LeaveReponse> CreateLeaveRequest(LeaveRequest leaveRequest);

        Task<LeaveReponse> EditLeaveRequest(LeaveRequest leaveRequest,int id);

        Task<LeaveReponse> ManageApproveLeaveRequest(RequestStatus RequestStatus, int id);

        Task<LeaveReponse> ManageRejectLeaveRequest(RequestStatus RequestStatus, int id);
    }
}
