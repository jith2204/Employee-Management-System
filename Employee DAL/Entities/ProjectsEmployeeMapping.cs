using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Entities
{
    public class ProjectsEmployeeMapping 
    {

        [Key]
        [Required]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

      
       


        [Required]
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employees Employee { get; set; }

       

       

        [Required]
        [ForeignKey("ProjectId")]
        public int ProjectId { get; set; }
        public Projects Project{ get; set; }

       

        
    }
}
