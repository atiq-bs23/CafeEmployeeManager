using CafeEmployeeManager.Core.Base;

namespace CafeEmployeeManager.Core.Entities
{
    public class EmployeeCafeAssignment : CoreDbEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid CafeId { get; set; }
        public DateTime StartDate { get; set; }
        public Employee Employee { get; set; }
        public Cafe Cafe { get; set; }
    }
}
