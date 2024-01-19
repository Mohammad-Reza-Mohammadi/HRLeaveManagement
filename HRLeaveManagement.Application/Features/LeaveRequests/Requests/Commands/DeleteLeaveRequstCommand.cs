using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequests.Requests.Commands
{
    public class DeleteLeaveRequstCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
