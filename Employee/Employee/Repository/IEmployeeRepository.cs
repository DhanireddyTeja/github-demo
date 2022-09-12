using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeModels> Get();
        EmployeeModels Post(EmployeeModels employee);
        EmployeeModels Put(EmployeeModels employee);
        bool Delete(int employeeId);
    }
}
