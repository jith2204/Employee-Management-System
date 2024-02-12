using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Entities
{
    public class Departments 
    {
        
        [Key]
        [Required]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Name { get; set; }

        
        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string? Description { get; set; }


        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public DateTime? DeletedOn { get; set; }

    }
}
