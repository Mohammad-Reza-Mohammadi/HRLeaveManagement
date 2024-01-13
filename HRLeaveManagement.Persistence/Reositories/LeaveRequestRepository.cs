using HRLeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Persistence.Reositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HrLeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(HrLeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestwithDetailsAsync(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(q=>q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestwithDetailsAsync()
        {
            var leaveRequests = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }
    }
}
