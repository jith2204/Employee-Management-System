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
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        protected readonly EmployeeContext _context;

        public RoleRepository(EmployeeContext context) : base(context)
        {
            _context = context;
        }

        public Role GetRole(int roleId)
        {
            return _context.Roles.Include(i => i.RoleMembers).FirstOrDefault(i => i.Id == roleId);

        }

    }
}
