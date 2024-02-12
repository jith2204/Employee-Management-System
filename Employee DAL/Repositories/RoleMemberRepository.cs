using Employee_DAL.ContextData;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Repositories
{
    public class RoleMemberRepository : GenericRepository<RoleMember>, IRoleMemberRepository
    {
        protected readonly EmployeeContext _context;

        public RoleMemberRepository(EmployeeContext context) : base(context)
        {
            _context = context;
        }

    }
}
