using BLL.Interfaces;
using DAL.ContextConfiguration;
using DAL.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repostioes
{
    public class EmployeeRepositorycs : GenericRepository<Employee>,IEmployeeRepository
    {
        

        public EmployeeRepositorycs(Dbcontext context) : base(context)
        {
          
        }

        public IQueryable<Employee> GetEmployeeAddres(string Address)
        {
            _dbcontext.employees.Where(p => p.Address == Address).ToList();
            return _dbcontext.employees;  
        }

        IQueryable<Employee> IEmployeeRepository.SerachValue(string name)
        {
          return  _dbcontext.employees.Where(e => e.Name.ToLower().Contains(name.ToLower()));
        }
    }
        

       

        
}
