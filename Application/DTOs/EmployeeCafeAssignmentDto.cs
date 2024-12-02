using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeManager.Application.DTOs
{
    public class EmployeeCafeAssignmentDto
    {
        public Guid EmployeeId { get; set; }
        public Guid CafeId { get; set; }
        public DateTime StartDate { get; set; }
    }
}
