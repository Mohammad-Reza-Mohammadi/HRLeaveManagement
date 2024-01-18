using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries;
using HRLeaveManagement.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRLeaveManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsControllerr : ControllerBase
    {
        private readonly IMediator _mediatR;

        public LeaveAllocationsControllerr(IMediator mediatR)
        {
            _mediatR = mediatR;
        }


        // GET: api/<LeaveAllocationsControllerr>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocation>>> Get()
        {
            var leaveAllocations = await _mediatR.Send(new GetLeaveAllocationDetailRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationsControllerr>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var LeaveAllocation = await _mediatR.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(LeaveAllocation);
        }

        // POST api/<LeaveAllocationsControllerr>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
        {
            var command = new CreateLeaveAllocationCommand { CreateLeaveAllocationDto = createLeaveAllocationDto };
            var response = await _mediatR.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveAllocationsControllerr>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UpdateLeaveAllocationDto updateLeaveAllocationDto)
        {
            var command = new UpdateLeaveAllocationCommand { UpdateLeaveAllocationDto = updateLeaveAllocationDto };
            await _mediatR.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsControllerr>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediatR.Send(command);
            return NoContent();
        }
    }
}
