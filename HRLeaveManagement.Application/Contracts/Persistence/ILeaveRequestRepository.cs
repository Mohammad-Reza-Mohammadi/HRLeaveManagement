using HRLeaveManagement.Domain;

namespace HRLeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestwithDetailsAsync(int id);

        Task<List<LeaveRequest>> GetLeaveRequestwithDetailsAsync();
        Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
    }
}
