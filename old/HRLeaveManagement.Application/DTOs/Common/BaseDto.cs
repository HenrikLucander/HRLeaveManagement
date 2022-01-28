using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.Common
{
    // Abstract cannot be instantiated on its own,
    // will be inherited by other DTOs
    public abstract class BaseDto
    {
        public int Id { get; set; }
    }
}
