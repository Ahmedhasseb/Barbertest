using AutoMapper;
using BLL.Interfaces;
using DAL.Moduls;
using DemoMvc.Helpers;
using DemoMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoMvc.Controllers
{
    public class EmployeeController : Controller
    {
     
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: EmployeeController
        public async Task< IActionResult> Index(string SearchValue)
        {

            if (string.IsNullOrEmpty(SearchValue))
            {
            var employee = await _unitOfWork.employeeRepository.GetAll();
           
            await _unitOfWork.Complete();

                var empmapper = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employee);
                return View(empmapper);
            }
            else
            {
                var emp=_unitOfWork.employeeRepository.SerachValue(SearchValue);
            var empmapper = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(emp);
            return View(empmapper);
            }
        }

        // GET: EmployeeController/Details/5
        public async Task< IActionResult> Details(int? id,string view= "Details")
        {
            ViewBag.depart =_unitOfWork.departmentRepostory.GetAll(); 
            if (id is null)
            {
              return  BadRequest();
            }
            var employee =await _unitOfWork.employeeRepository.Get(id.Value);
           await _unitOfWork.Complete();
            if (employee is  null)
            {
                return NotFound();
            }
            var empmapper = _mapper.Map<Employee, EmployeeViewModel>(employee);
            
            return View( view, empmapper);
           
        }

        // GET: EmployeeController/Create
        public IActionResult Create()
        {

           
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeVM)
        {
            if (ModelState.IsValid)
            {
                employeeVM.ImageName = DocumentSettings.uploadFile(employeeVM.Image,"image");
                var empmapper = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
               await _unitOfWork.employeeRepository.Add(empmapper);
               await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));    
            }
            return View(employeeVM);
        }

        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id, EmployeeViewModel employeeVM)
        {
            if (id!= employeeVM.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var empmaper = _mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                    _unitOfWork.employeeRepository.Update(empmaper);
                  await  _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(employeeVM);
        }

        // GET: EmployeeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, EmployeeViewModel employeeVM)
        {
            if (id!= employeeVM.Id)
            {
                return BadRequest();
            }
            try
            {
               var empmapper=_mapper.Map<EmployeeViewModel, Employee>(employeeVM);
                  _unitOfWork. employeeRepository.Delete(empmapper);
              await _unitOfWork.Complete();
                
                    DocumentSettings.DeleteFile(empmapper.ImageName, "image");

                
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(employeeVM);
        }
    }
}
