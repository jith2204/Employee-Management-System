using Employee_DAL.ContextData;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Repositories
{
    public class UserRegisterRepository : GenericRepository<UserRegister>, IUserRegisterRepository
    {
        protected readonly EmployeeContext _context;


        public UserRegisterRepository(EmployeeContext context) : base(context)
        {
            _context = context;
        }

        public UserRegister Get(string email, string password)
        {
            return _context.Users.Include(i => i.RoleMembers).FirstOrDefault(i => i.Email == email && i.Password == password);
        }
    }
}
