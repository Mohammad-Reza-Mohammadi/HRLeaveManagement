using HRLeaveManagement.Application.DTOs.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRLeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestDto>>> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestListRequest());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveReaquestDetailRequest { Id = id });
            return leaveRequest;
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var command = new CreateLeaveRequestCommand { CreateLeaveRequestDto = createLeaveRequestDto };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var command = new UpdateLeaveRequestCommand {  UpdateLeaveRequestDto = updateLeaveRequestDto };
            await _mediator.Send(command);
            return NoContent();
        }

        //PUT api/<LeaveRequestsController>/changeapproval
        [HttpPut("changeapproval")]
        public async Task<ActionResult> ChangeApproval([FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto)
        {
            var command = new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequstCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
