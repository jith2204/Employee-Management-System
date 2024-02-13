
using Employee_BAL.Model;
using Employee_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_BAL.Interfaces
{
    public interface IEmployeeService 
    {

        EmployeeModel Add(EmployeeModel employeeModel);

        List<EmployeeIdModel> GetAll();

        EmployeeModel Remove(int id);

        EmployeeModel Update(int id, EmployeeModel employeeModel);

        EmployeeModel GetByEmployeeId(int id);       
    }
}
