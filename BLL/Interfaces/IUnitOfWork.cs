using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUnitOfWork
    {
        public IDepartmentRepostory departmentRepostory { get; set; }
        public IEmployeeRepository employeeRepository { get; set; }

        public IClient Client { get; set; } 
        public IGallery Gallery { get; set; }
        public IHairArtist HairArtist { get; set; }

         Task<int> Complete();
    }
}
