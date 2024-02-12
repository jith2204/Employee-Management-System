
using Employee_BAL.Model;
using Employee_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Interfaces
{
    public interface IDepartmentService 
    {

        DepartmentModel Add(DepartmentModel departmentModel);

        List<DepartmentIdModel> GetAll();

        DepartmentModel Remove(int id);

        DepartmentModel Update(int id, DepartmentModel departmentModel);

       


    }
}
