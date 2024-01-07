using HRLeaveManagement.Application.DTOs.common;
using HRLeaveManagement.Application.DTOs.Leavetype;
using HRLeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }

        public LeaveTypeDto? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }

        public int Period { get; set; }
    }
}
