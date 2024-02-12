using Employee_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Interfaces
{
    public interface IUserRegisterRepository : IGenericRepository<UserRegister>
    {
        UserRegister Get(string email, string password);
    }
}
