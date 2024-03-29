﻿using HRLeaveManagement.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDto : ILeaveRequstDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public string requestComments { get; set; }
    }
}
