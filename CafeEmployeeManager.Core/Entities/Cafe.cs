using CafeEmployeeManager.Core.Base;

namespace CafeEmployeeManager.Core.Entities
{
    public class Cafe : CoreDbEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Location { get; set; }
    }
}
