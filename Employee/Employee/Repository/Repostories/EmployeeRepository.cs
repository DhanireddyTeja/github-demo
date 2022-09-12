using Employee.DataAccess;
using Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Repository.Repostories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public List<EmployeeModels> Get()
        {
            var list = _context.employee.ToList();
            return list;
        }

        public EmployeeModels Post(EmployeeModels model)
        {
            _context.employee.AddAsync(model);
            _context.SaveChangesAsync();
            return model;
        }
        
        public EmployeeModels Put(EmployeeModels model)
        {
            var employeesToEdit = _context.employee.Where(x => x.Id == model.Id).FirstOrDefault();
            employeesToEdit.Age = model.Age;
            employeesToEdit.FirstName = model.FirstName;
            employeesToEdit.LastName = model.LastName;

            _context.SaveChanges();
            return employeesToEdit;
        }

      
        public bool Delete(int id)
        {
            var employees = _context.employee.Where(x => x.Id == id).FirstOrDefault();
            _context.employee.Remove(employees);
            _context.SaveChanges();

            return true;
        }

      /*  public List<EmployeeModels> Get()
        {
            throw new NotImplementedException();
        }

        public EmployeeModels Post(EmployeeModels employee)
        {
            throw new NotImplementedException();
        }

        public EmployeeModels Put(EmployeeModels employee)
        {
            throw new NotImplementedException();
        }*/
    }
}
