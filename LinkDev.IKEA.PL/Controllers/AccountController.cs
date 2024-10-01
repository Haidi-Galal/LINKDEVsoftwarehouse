using LinkDev.IKEA.DAL.Entities.Identity;
using LinkDev.IKEA.PL.ViewModels.Identtity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.IKEA.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager ) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            
        
        
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
		public  async Task <IActionResult> SignUp(SignUpViewModel signUpViewModel)
		{
            if (!ModelState.IsValid)
                return BadRequest();
		var user= await _userManager.FindByNameAsync(signUpViewModel.userName);

            if(user is { })
            {
                ModelState.AddModelError(string.Empty, "User Name Already Exists ");
                return View(signUpViewModel);
            }
			 user = new ApplicationUser() 
            
            { 
                Email=signUpViewModel.Email,
                FName= signUpViewModel.FName,
                LName= signUpViewModel.LName,
                IsAgree=signUpViewModel.IsAgree,
                UserName= signUpViewModel.userName,
                
			};

          var result= await _userManager.CreateAsync(user, signUpViewModel.Password);
            if (result.Succeeded)
            {
                Console.WriteLine("Hamada");
                return RedirectToAction(nameof(SignIn));
            }
            else
            {
                foreach(var error in result.Errors)
                    ModelState.AddModelError(string.Empty,error.Description);
                return View(signUpViewModel);
            }

		}


	}
}
