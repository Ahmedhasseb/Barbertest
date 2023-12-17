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
    public class DepartmentRepostory : GenericRepository<Department>,IDepartmentRepostory
    {
        private readonly Dbcontext _context;

        public DepartmentRepostory(Dbcontext context):base(context)//Ask ClR for Creation
        {
            _context = context;
        }
    }
    }
