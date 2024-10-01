using LinkDev.IKEA.BLL.Models.Departments;
using LinkDev.IKEA.BLL.Services.Departments;
using LinkDev.IKEA.PL.ViewModels.Deparments;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {  private readonly IDepartmentService _departmentService;
       private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DepartmentController(IDepartmentService departmentService,ILogger<DepartmentController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _webHostEnvironment=webHostEnvironment;
        }

        [HttpGet] //Department/Index
        public IActionResult Index()
        {
           var departments= _departmentService.GetDepartmentsAsync();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create(CreatedDepartmentDto createddepartmentdto)
        {   if (!ModelState.IsValid)
                return View(createddepartmentdto);
            try
            {
                var result = await _departmentService.CreateDepartmentAsync(createddepartmentdto) > 0;
                if (result)
                    return RedirectToAction(nameof(Index));

            }
            catch(Exception ex)
            {
                //1.log exception
                _logger.LogError(ex, ex.Message);
                if (_webHostEnvironment.IsDevelopment())
                {
                    return View("Error", ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Deparment not created :(");

                }


            }
            return View(createddepartmentdto);

        }
        
        [HttpGet]
        public async Task< IActionResult> Details(int? id)
        {     if (id is null)
                return BadRequest();
           var dapartment= await _departmentService.GetDepartmentByIdAsync(id.Value);
            if (dapartment is null)
                return NotFound();
            return View(dapartment);
        }

        [HttpGet]
        public async Task< IActionResult> Edit(int? id)
        {
            if (id is null)
                return BadRequest();
           var department= await _departmentService.GetDepartmentByIdAsync(id.Value);
            if (department is null)
            {

                return NotFound();
            }
            return View(new DepartmentEditViewModel() 
            
            {
                Code=department.Code,
                Name=department.Name,
                CreationDate=department.CreationDate,
                Description=department.Description
            
            
            });

         

        }
        [HttpPost]
        public async  Task<IActionResult> Edit(int id,DepartmentEditViewModel department)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "error in updating !!");
                Console.WriteLine(department.Code);
                return View(department);
                
            }
            else
            {
                var message = string.Empty;


                try
                {
                   var updated=  await _departmentService.UpdateDepartmentAsync(new UpdatedDepartmentDto()
                    {
                        Code = department.Code,
                        CreationDate = department.CreationDate,
                        Id = id,
                        Description = department.Description,
                        Name = department.Name
                    }
                  )>0;
                    if(updated)
                    return RedirectToAction(nameof(Index));
                    message = "an error occured during updating department";

                }
                catch(Exception ex)
                {
                    _logger.LogError(string.Empty, message);
                    message = _webHostEnvironment.IsDevelopment() ? ex.Message : "an error occured during updating department";

                }
                ModelState.AddModelError(string.Empty,message);
                return View(department);
            }

        }
        [HttpPost]
        public async  Task<IActionResult> Delete(int id)
        {
            var message = string.Empty;
            try
            {
                var deleted = await _departmentService.DeleteDepartmentAsync(id);
                if(deleted)
                return RedirectToAction(nameof(Index));

                message = "an error occured in deleting !";

            }
            catch (Exception ex)
            {
                _logger.LogError(string.Empty, ex.Message);

               message= _webHostEnvironment.IsDevelopment()?ex.Message:"an error occured in deleting";

            }

            return RedirectToAction(nameof(Index));

        }

    }
}
