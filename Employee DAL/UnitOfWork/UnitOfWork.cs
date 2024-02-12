using Employee_DAL.ContextData;
using Employee_DAL.Entities;
using Employee_DAL.Interfaces;
using Employee_DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
       private readonly EmployeeContext _context;

        public UnitOfWork(EmployeeContext context)
        {
            _context = context;
            Employee = new EmployeeRepository(_context);
            Department = new DepartmentRepository(_context);   
            Project = new ProjectRepository(_context);
            ProjectsEmployeeMapping = new ProjectsEmployeeMappingRepository(_context);
            User = new UserRegisterRepository(_context);
            Account = new AccountRepository(_context);
            Role = new RoleRepository(_context);
            RoleMember = new RoleMemberRepository(_context);
        }

        

        public IDepartmentRepository Department { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IProjectRepository Project { get; private set; }
        public IProjectsEmployeeMappingRepository ProjectsEmployeeMapping { get; private set; }

        public IUserRegisterRepository User { get; private set; }

        public IAccountRepository Account { get; private set; }

        public IRoleRepository Role { get; private set; }

        public IRoleMemberRepository RoleMember { get; private set; }

        public int Commit()
        {
            return _context.SaveChanges();
        }

      

        public void Dispose()
        {
            _context.Dispose();
        }

        
    }
}
