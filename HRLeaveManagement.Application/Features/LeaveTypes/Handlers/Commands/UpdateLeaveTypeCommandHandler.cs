using AutoMapper;
using HRLeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HRLeaveManagement.Application.DTOs.Leavetype.Validators;
using HRLeaveManagement.Application.Exeptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {

            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationEception(validationResult); 

            var leaveType = await _leaveTypeRepository.GetAsync(request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, leaveType);

            await _leaveTypeRepository.UpdateAsync(leaveType);

            return Unit.Value;
        }
    }
}
