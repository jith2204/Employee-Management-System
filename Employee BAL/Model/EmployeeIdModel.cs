﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Model
{
    public class EmployeeIdModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string Email { get; set; }
        public decimal Score { get; set; }

        public int DepartmentId { get; set; }
    }
}
