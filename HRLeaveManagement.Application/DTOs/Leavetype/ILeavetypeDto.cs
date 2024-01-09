using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.DTOs.Leavetype
{
    public interface ILeavetypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
