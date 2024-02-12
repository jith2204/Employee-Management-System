using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employee { get; }

        IDepartmentRepository Department { get; }
        IProjectRepository Project { get; }
        IProjectsEmployeeMappingRepository ProjectsEmployeeMapping { get; }

        IUserRegisterRepository User {  get; }

        IAccountRepository Account { get; }

        IRoleRepository Role { get; }

        IRoleMemberRepository RoleMember { get; }



        int Commit();
    }
}
