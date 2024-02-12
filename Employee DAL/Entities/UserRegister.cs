using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Entities
{
    public class UserRegister
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string Password { get; set; }

        public DateTime? RegisteredOn { get; set; }

        public ICollection<RoleMember> RoleMembers { get; set; }
    }
}
