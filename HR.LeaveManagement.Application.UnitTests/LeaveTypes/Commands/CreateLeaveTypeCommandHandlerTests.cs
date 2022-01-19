using AutoMapper;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using HRLeaveManagement.Application.Contracts.Persistance;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Exceptions;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HRLeaveManagement.Application.Profiles;
using HRLeaveManagement.Application.Responses;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        // Need mapper and (mock)repo to interact with the handler
        // As we are not injecting the real ones, we need to set them up in the ctor
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;
        private readonly CreateLeaveTypeCommandHandler _handler; // Need the handler we are about to test
        private readonly CreateLeaveTypeDto _createLeaveTypeDto; // The CreateLeaveTypeCommand needs a CreateLeaveTypeDto

        public CreateLeaveTypeCommandHandlerTests()
        {
            // Set the repo to mock repo
            _mockRepo = MockLeaveTypeRepository.GetLeaveTypeRepository();

            // As mapper is not injected,
            // we need the mapper to know about the mapping configurations in the Application layer.
            // Thus represents the real mapper.
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            // Instantiate the handler with the mock repo and mapper
            _handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

            // Instantiate the CreateLeaveTypeDto
            _createLeaveTypeDto = new CreateLeaveTypeDto
            {
                DefaultDays = 15,
                Name = "Test DTO"
            };
        }

        [Fact]
        public async Task Valid_LeaveType_Added()
        {
            // Pass the request and cancellationToken to the handler
            var result = _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _createLeaveTypeDto }, CancellationToken.None);

            // GetAll() to check that count is right (in the assert section)
            var leaveTypes = await _mockRepo.Object.GetAll();

            // Using Shouldly for assert
            await result.ShouldBeOfType<Task<BaseCommandResponse>>();
            leaveTypes.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Invalid_LeaveType_Added()
        {
            // Set DefaultDays to invalid value ( < 1 )
            _createLeaveTypeDto.DefaultDays = -1;

            // Testing for a ValidationException         
            ValidationException ex = await Should.ThrowAsync<ValidationException>
                (async () =>
                    // Pass the request and cancellationToken to the handler
                    await _handler.Handle(new CreateLeaveTypeCommand() { LeaveTypeDto = _createLeaveTypeDto }, CancellationToken.None)
                );

            // GetAll() to check that count is right (in the assert section)
            var leaveTypes = await _mockRepo.Object.GetAll();

            // Using Shouldly for assert (should "still" be 3 as the LeaveType was invalid)
            leaveTypes.Count.ShouldBe(3);
        }
    }
}
