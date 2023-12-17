using AutoMapper;
using DAL.Moduls;
using DemoMvc.Models;

namespace DemoMvc.Mapper
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
