using Azure;
using InterviewPratice.Data;
using InterviewPratice.Interface;
using InterviewPratice.Models.Request;
using InterviewPratice.Models.RequestDto;
using InterviewPratice.Models.Response;
using LeaveManagement.Models.RequestDto;
using Microsoft.EntityFrameworkCore;

namespace InterviewPratice.Services
{
    public class LeaveRequestService : ILeaveRequestService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public LeaveRequestService(ApplicationDbContext ApplicationDbContext) 
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        //Using Synchronous withouth:task,async and await
        public List<LeaveRequest> GetLeaveRequestDetails()
        {
           
            var listt= new List<LeaveRequest>();

            listt  = _ApplicationDbContext.LeaveRequest.FromSqlRaw("SP_LeaveRequestDetails").ToList();

            //or
            //List < LeaveRequest > list = _ApplicationDbContext.LeaveRequest.FromSqlRaw("SP_LeaveRequestDetails").ToList();

            return listt;
        }

        public LeaveRequest GetLeaveRequestDetailsByID(int id)
        {
            var response =_ApplicationDbContext.LeaveRequest.FromSql($"SP_LeaveRequestDetailsByID {id}").ToList();

            // or var response = _ApplicationDbContext.LeaveRequest.FromSql($"SP_LeaveRequestDetailsByID {id}").AsEnumerable().FirstOrDefault();
            // or return response;

            // or var response = _ApplicationDbContext.LeaveRequest.FromSql($"SP_LeaveRequestDetailsByID {id}");
            // or return response.AsEnumerable().FirstOrDefault();

            return response.FirstOrDefault();

        }

        public async Task<LeaveReponse> CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            var reponse = await _ApplicationDbContext.Set<LeaveReponse>().FromSqlInterpolated($"Exec SP_CreateLeaveRequest @employeeId={leaveRequest.employeeId},@LeaveType={leaveRequest.LeaveType},@LeaveSummary={leaveRequest.LeaveSummary},@No_of_days={leaveRequest.No_of_days},@AvailableLeave={leaveRequest.AvailableLeave}").ToListAsync();

            //return new LeaveReponse { LeaveApplicationRsponse = reponse.FirstOrDefault().ToString() };
            return reponse.FirstOrDefault();
        }

        public async Task<LeaveReponse> EditLeaveRequest(LeaveRequest leaveRequest, int id)
        {
            var reponse = await _ApplicationDbContext.Set<LeaveReponse>().FromSqlInterpolated($"Exec SP_EditLeaveRequest @employeeId={id},@LeaveType={leaveRequest.LeaveType},@LeaveSummary={leaveRequest.LeaveSummary},@No_of_days={leaveRequest.No_of_days},@AvailableLeave={leaveRequest.AvailableLeave}").ToListAsync();

            //return new LeaveReponse { LeaveApplicationRsponse = reponse.FirstOrDefault().ToString() };
            return reponse.FirstOrDefault();
        }

        //manager approve the leave request, they avaible leave balance should reduce

        public async Task<LeaveReponse> ManageApproveLeaveRequest(RequestStatus RequestStatus, int id)
        {
            var reponse = await _ApplicationDbContext.Set<LeaveReponse>().FromSqlInterpolated($"Exec SP_ManageLeaveRequest @id={id},@employeeId={RequestStatus.employeeId},@ApproveOrReject={RequestStatus.ApproveOrReject},@No_of_days={RequestStatus.No_of_days}").ToListAsync();

            return reponse.FirstOrDefault();
        }

        public async Task<LeaveReponse> ManageRejectLeaveRequest(RequestStatus RequestStatus, int id)
        {
            var reponse = await _ApplicationDbContext.Set<LeaveReponse>().FromSqlInterpolated($"Exec SP_ManageLeaveRequest @id={id},@employeeId={RequestStatus.employeeId},@ApproveOrReject={RequestStatus.ApproveOrReject},@No_of_days={RequestStatus.No_of_days}").ToListAsync();

            return reponse.FirstOrDefault();
        }


    }
}
