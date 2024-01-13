using AutoMapper;
using HRLeaveManagement.Application.DTOs.Leavetype;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var LeaveTypes = await _leaveTypeRepository.GetAllAsync();
            return _mapper.Map<List<LeaveTypeDto>>(LeaveTypes);
        }
    }
}
