using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Model
{
    public class ProjectsEmployeeMappingIdModel
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }







        public int ProjectId { get; set; }
    }
}
