﻿using HRLeaveManagement.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveAllocation
{
    public class UpdateLeaveAllocationDto : BaseDto, ILeaveAllocationDto
    {
        public int NumberOfdays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
