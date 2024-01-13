using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestwithDetailsAsync(int id);

        Task<List<LeaveRequest>> GetLeaveRequestwithDetailsAsync();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
