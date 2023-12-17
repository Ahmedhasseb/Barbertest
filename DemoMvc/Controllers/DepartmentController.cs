using BLL.Interfaces;
using DAL.Moduls;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace DemoMvc.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepostory _departmentRepostory;
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
         
           _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var department =await _unitOfWork.departmentRepostory.GetAll();
           await _unitOfWork.Complete();

            return View(department);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
              await  _unitOfWork.departmentRepostory.Add(department);
               await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public async Task<IActionResult> Details(int? id, string view = "Details")
        {
            if (id is null)
            {
                return BadRequest();

            }
            var department =await _unitOfWork.departmentRepostory.Get(id.Value);
           await _unitOfWork.Complete();
            if (department is null)
            {
                return NotFound();
            }
            return View(view, department);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.departmentRepostory.Update(department);
                   await _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(department);
        }

        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            try
            {
                 _unitOfWork.departmentRepostory.Delete(department);
               await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));

            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(department);
        }

        
    
    }
}
