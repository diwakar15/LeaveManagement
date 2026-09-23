using InterviewPratice.Interface;
using InterviewPratice.Models.Request;
using InterviewPratice.Services;
using LeaveManagement.Models.RequestDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewPratice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ILeaveRequestService _LeaveRequestService;

        public LeaveRequestController(ILeaveRequestService LeaveRequestService)
        {
            _LeaveRequestService = LeaveRequestService;
        }


        //Using Synchronous withouth:task,async and await
        [HttpGet("LeaveRequest")]
        public IActionResult GetLeaveRequestDetails()
        {
            var LeaveRequestDetails = _LeaveRequestService.GetLeaveRequestDetails();
            return Ok(LeaveRequestDetails);
        }

        [HttpGet("LeaveRequest/{id}")]
        public IActionResult GetLeaveRequestDetailsByID(int id)
        {
            var LeaveRequestDetails = _LeaveRequestService.GetLeaveRequestDetailsByID(id);
            return Ok(LeaveRequestDetails);
        }

        //using Asynchronous : task,async and await
        [HttpPost("CreateLeaveRequest")]
        public async Task<IActionResult> CreateLeaveRequest(LeaveRequest leaveRequest)
        {
            var response = await _LeaveRequestService.CreateLeaveRequest(leaveRequest);

            return Ok(response);
        }

        [HttpPut("EditLeaveRequest/{id}")]
        public async Task<IActionResult> EditLeaveRequest(LeaveRequest leaveRequest, int id)
        {
            var response = await _LeaveRequestService.EditLeaveRequest(leaveRequest,id);
            return Ok(response);
        }

        [HttpPut("ManageApproveLeaveRequest/{id}")]
        public async Task<IActionResult> ManageApproveLeaveRequest(RequestStatus RequestStatus, int id)
        {
            var response = await _LeaveRequestService.ManageApproveLeaveRequest(RequestStatus, id);
            return Ok(response);
        }

        [HttpPut("ManageRejectLeaveRequest/{id}")]
        public async Task<IActionResult> ManageRejectLeaveRequest(RequestStatus RequestStatus, int id)
        {
            var response = await _LeaveRequestService.ManageRejectLeaveRequest(RequestStatus, id);
            return Ok(response);
        }

    }
}
