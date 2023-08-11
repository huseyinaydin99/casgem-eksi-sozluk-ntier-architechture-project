using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Areas.Admin.Models;
using EksiSozluk.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginViewModel = EksiSozluk.PresentationLayer.Models.LoginViewModel;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string user = ViewBag.username;
            if (user != null)
            {
                HttpContext.Session.SetString("username", user);
                return View(new SessionViewModel { UserName = user });
            }
            else
            {
                return View(new SessionViewModel { UserName = "" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, false);
            if (result.Succeeded)
            {
                ViewBag.username = model.UserName;
                HttpContext.Session.SetString("username", model.UserName);
                return Redirect("/Default/Index");
            }
            return View();
        }
    }
}