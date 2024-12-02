using CafeEmployeeManager.Core.Base;
using CafeEmployeeManager.Core.Enums;

namespace CafeEmployeeManager.Core.Entities
{
    public class Employee : CoreDbEntity
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
    }
}
