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
    public class ProjectsEmployeeMappingRepository : GenericRepository<ProjectsEmployeeMapping>, IProjectsEmployeeMappingRepository
    {
        readonly EmployeeContext _context;
        public ProjectsEmployeeMappingRepository(EmployeeContext context) : base(context)
        {
            _context = context;

        }

       /* public ProjectsEmployeeMapping AssignEmployee(ProjectsEmployeeMapping item)
        {
            _context.ProjectsEmployeeMappings.Add(item);
            return item;
        }*/

        public List<ProjectsEmployeeMapping> EmployeeWorkingProjects(int employeeId)
        {
            return _context.ProjectsEmployeeMappings.Include(i=>i.Employee).Include(i => i.Project).Where(x => x.EmployeeId == employeeId).ToList();
        }

        public List<ProjectsEmployeeMapping> GetAssignedEmployees(int projectId)
        {
            return _context.ProjectsEmployeeMappings.Include(i => i.Employee).Include(i => i.Project).Where(x => x.ProjectId == projectId).ToList();
        }
    }
}
