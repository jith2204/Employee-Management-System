using Employee_DAL.Entities;
using Employee_DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Model
{
    public class EmployeeModel 
    {
        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; } 

        public string Email { get; set; }

        public Gender Gender { get; set; }
       
        public decimal Score { get; set; }

        public decimal? Salary { get; set; }

        public DateTime? DOB { get; set; }

        public int DepartmentId { get; set; }
    }
}
