﻿using HRLeaveManagement.Application.DTOs.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.Leavetype
{
    public class LeaveTypeDto : BaseDto, ILeavetypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
