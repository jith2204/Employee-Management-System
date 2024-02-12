using Employee_BAL.Model;
using Employee_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Interfaces
{
    public interface IProjectService
    {
        ProjectModel Add(ProjectModel projectModel);

        List<ProjectIdModel> GetAll();

        ProjectModel Remove(int id);

        ProjectModel Update(int id, ProjectModel projectModel);

        ProjectModel GetById(int id);


    }
}
