using HRLeaveManagement.Application.Persistence.Contracts;
using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Persistence.Reositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HrLeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(HrLeaveManagementDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
