using Employee_DAL.ContextData;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employees>, IEmployeeRepository
    {
        readonly EmployeeContext _context;


        public EmployeeRepository(EmployeeContext context) : base(context)
        {
            _context = context;
        }

       

     

     

       




    }
}

