using Employee_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Model
{
    public class UserRegisterModel
    {
        

        
        public string Email { get; set; } 

        public string Password { get; set; }

        public int RoleId { get; set; }

    }
}
