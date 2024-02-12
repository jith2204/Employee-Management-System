using Employee_BAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Interfaces
{
    public interface IUserRegisterService
    {
        UserRegisterModel Register(UserRegisterModel userModel);
    }
}
