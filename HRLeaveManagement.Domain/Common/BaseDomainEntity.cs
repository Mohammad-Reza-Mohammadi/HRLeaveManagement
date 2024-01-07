namespace HRLeaveManagement.Domain.Common
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreateBy { get; set; }
        public string LastModifiedDate { get; set; }
        public string  LastModifiedBy { get; set; }
    }
}
