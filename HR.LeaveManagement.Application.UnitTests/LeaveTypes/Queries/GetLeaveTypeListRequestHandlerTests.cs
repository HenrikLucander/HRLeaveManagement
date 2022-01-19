using AutoMapper;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using HRLeaveManagement.Application.Contracts.Persistance;
using HRLeaveManagement.Application.DTOs.LeaveType;
using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HRLeaveManagement.Application.Profiles;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Queries
{
    public class GetLeaveTypeListRequestHandlerTests
    {
        // Need mapper and (mock)repo to interact with the handler
        // As we are not injecting the real ones, we need to set them up in the ctor
        private readonly IMapper _mapper;
        private readonly Mock<ILeaveTypeRepository> _mockRepo;

        public GetLeaveTypeListRequestHandlerTests()
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
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            // Instantiate the handler with the mock repo and mapper
            var handler = new GetLeaveTypeListRequestHandler(_mockRepo.Object, _mapper);

            // Pass the request and cancellationToken to the handler
            var result = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            // Using Shouldly for assert
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
