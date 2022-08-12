using eTicket.Data;
using eTicket.Models;
using eTicket.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTicket.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _context;

        private UserManager<ApplicationUser> _userManager { get; set; }
        private SignInManager<ApplicationUser> _signInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager,
                                    SignInManager<ApplicationUser> signInManager,
                                    AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = appDbContext;
        }



        public IActionResult Login() => View(new LoginVM());


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var pwdCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (pwdCheck)
                {
                    var result = _signInManager.PasswordSignInAsync(user,loginVM.EmailAddress,false,false);
                    if (result.IsCompletedSuccessfully)
                    {
                        return RedirectToAction("Index","Movies");
                    }
                }
                TempData["Error"] = "Invalid credentials, Please try again.";
                return View(loginVM);
            }
            TempData["Error"] = "Invalid credentials, Please try again.";
            return View(loginVM);
        }
    }
}
