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
    public class AccountRepository : GenericRepository<UserRegister>, IAccountRepository
    {
        public AccountRepository(EmployeeContext context) : base(context)
        {
        }
        public List<RoleMember> User(int userId)
        {
            return _context.RoleMembers.Include(i => i.Users).Include(i => i.Roles).Where(x => x.UserId== userId).ToList();
        }

        public List<RoleMember> GetAssignedEmployees(int roleId)
        {
            return _context.RoleMembers.Include(i => i.Users).Include(i => i.Roles).Where(x => x.RoleId == roleId).ToList();
        }

    }
}

