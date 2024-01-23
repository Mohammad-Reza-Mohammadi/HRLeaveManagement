using AutoMapper;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Application.DTOs.Leavetype;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.UnitTests.Mocks;
using HRLeaveManagement.Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.LeaveTypes.Command
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeDto _createLeaveTypeDto;
        private readonly CreateLeaveTypeCommandHandler _handler;

        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });

            _mapper = new Mapper(mapperConfig);

            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            _createLeaveTypeDto = new CreateLeaveTypeDto()
            {
                DefaultDays = 15,
                Name = "Test Dto"
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _createLeaveTypeDto }, CancellationToken.None);

            var leatetypes = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<int>();

            leatetypes.Count.ShouldBe(4);
        }

        [Fact]
        public async Task InValid_LeaveType_Added()
        {
            _createLeaveTypeDto.DefaultDays = -1;

            ValidationException ex = await Should.ThrowAsync<ValidationException>
                (async () =>
                        await _handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _createLeaveTypeDto }, CancellationToken.None)
                );
            var leaveTypes = await _mockRepo.Object.GetAllAsync();

            leaveTypes.Count.ShouldBe(3);

            ex.ShouldNotBeNull();
        }
    }
}
