using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Moduls
{
    public class Department
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOnlyTime { get; set; }

        public ICollection<Employee> Employee { get; set; }=new HashSet<Employee>();
    }
}
