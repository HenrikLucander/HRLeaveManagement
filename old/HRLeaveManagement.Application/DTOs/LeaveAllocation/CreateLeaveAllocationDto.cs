using HRLeaveManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation
{
    /// <summary>
    /// Doesn't inherit from BaseDto, because Id is not needed on creation.
    /// (no reference to primary key)
    /// </summary>
    public class CreateLeaveAllocationDto
    {
        public int LeaveTypeId { get; set; }
    }
}
