using HRLeaveManagement.Application.DTOs;
using HRLeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveAllocations.Requests.Queries
{
    public class GetLeaveAllocationDetailRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
