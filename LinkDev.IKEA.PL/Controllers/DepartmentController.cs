using LinkDev.IKEA.BLL.Models.Departments;
using LinkDev.IKEA.BLL.Services.Departments;
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
           var departments= _departmentService.GetDepartments();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto createddepartmentdto)
        {   if (!ModelState.IsValid)
                return View(createddepartmentdto);
            try
            {
                var result = _departmentService.CreateDepartment(createddepartmentdto) > 0;
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
        public IActionResult Details(int? id)
        {     if (id is null)
                return BadRequest();
           var dapartment= _departmentService.GetDepartmentById(id.Value);
            if (dapartment is null)
                return NotFound();
            return View(dapartment);
        }

    }
}
