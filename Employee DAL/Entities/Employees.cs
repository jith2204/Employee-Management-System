using Employee_DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Entities
{
    public class Employees 
    {



        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string? Email { get; set; }



        
        [Column(TypeName = "VARCHAR")]
        [StringLength(15)]

        public string? PhoneNo { get; set; }

        
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string? Address { get; set; }


        public Gender  Gender { get; set; }

        

        public DateTime? DOB { get; set; }

        public decimal Score { get; set; }

        public decimal? Salary { get; set; }

        


        [Required]
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Departments Department { get; set; }





    }
   
}
