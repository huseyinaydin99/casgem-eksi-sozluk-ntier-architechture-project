using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailConfirmController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public MailConfirmController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.username = TempData["code"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmViewModel model)
        {
            //ViewBag.username = TempData["username"].ToString();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user.ConfirmCode.ToString() == model.ConfirmCode.ToString())
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}