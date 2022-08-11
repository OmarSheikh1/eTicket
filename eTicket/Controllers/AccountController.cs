using eTicket.Data;
using eTicket.Models;
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



        public IActionResult Index()
        {
            return View();
        }
    }
}
