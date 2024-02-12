using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Entities
{
    public class RoleMember
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [Column(TypeName = "INT")]
        [ForeignKey("UserId")]
        public UserRegister Users { get; set; }
        public int UserId { get; set; }




        [Column(TypeName = "INT")]
        [ForeignKey("RoleId")]
        public Role Roles { get; set; }
        public int RoleId { get; set; }
    }
}
