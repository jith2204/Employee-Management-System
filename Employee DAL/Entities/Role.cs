using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Entities
{
    public class Role
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        public string Roles { get; set; }

        [StringLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Description { get; set; }

        public ICollection<RoleMember> RoleMembers { get; set; }
    }
}
