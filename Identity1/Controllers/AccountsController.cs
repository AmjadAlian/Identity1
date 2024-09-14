using Identity1.Data;
using Identity1.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity1.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(ApplicationDbContext context , UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(RegisterVM model)
        {
            IdentityUser user = new IdentityUser()
            {
                UserName = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

           var result = await userManager.CreateAsync(user,model.Password);
           if (result.Succeeded)
            return RedirectToAction(nameof(Login));
            
            return View(nameof(Register),model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(LoginVM model)
        {

            var result = await signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }

            return View(model);

         
        }
    }
}
