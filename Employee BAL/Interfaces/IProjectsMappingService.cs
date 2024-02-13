using Employee_BAL.Model;
using Employee_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Interfaces
{
    public interface IProjectsMappingService
    {
        List<ProjectsEmployeeMappingModel> EmployeeWorkingProjects(int employeeId);
        ProjectsEmployeeMappingModel Add(ProjectsEmployeeMappingModel mappingModel);
        List<ProjectsEmployeeMappingModel> GetAssignedEmployees(int projectId);
        List<ProjectsEmployeeMappingIdModel> GetAllMappingData();
    }
}
