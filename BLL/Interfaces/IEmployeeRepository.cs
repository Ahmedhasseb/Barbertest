using DAL.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeeAddres(string Address);
         IQueryable<Employee> SerachValue(string name);
    }
}
