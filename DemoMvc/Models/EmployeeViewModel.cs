using DAL.Moduls;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace DemoMvc.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Name is Required")]
        [MaxLength(50,ErrorMessage ="Name is Maxlength 50 Char")]
        [MinLength(3, ErrorMessage = "Name is Minlength 3 Char")]
        public string Name { get; set; }
        [Range(18,60)]
        public int? Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }    
        public string ImageName { get; set; }
        public bool IActive { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime HerDate { get; set; }
      

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
