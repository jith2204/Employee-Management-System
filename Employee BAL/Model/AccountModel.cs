using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Model
{
    public class AccountModel
    {
        public string Email { get; set; } = string.Empty;


        public string Password { get; set; } = string.Empty;

        public int RoleId { get; set; }
    }
}
