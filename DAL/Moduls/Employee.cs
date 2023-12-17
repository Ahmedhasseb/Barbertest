﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Moduls
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set;}
        public decimal Salary { get; set;}
        public string Email { get; set;}
        public string ImageName { get; set;}
        public bool IActive { get; set;} 
        public int PhoneNumber { get; set;}
        public DateTime HerDate { get; set;}
        public DateTime CreationDate { get; set;} = DateTime.Now;

        public int DepartmentId { get; set;}
        public Department Department { get; set;}
    }
}
