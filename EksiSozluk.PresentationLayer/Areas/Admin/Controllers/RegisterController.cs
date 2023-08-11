using EksiSozluk.CoreLayer.Utilities.EmailUtility;
using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace EksiSozluk.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            /*Random rnd = new Random();
            int x = rnd.Next(100000, 1000000);*/
            AppUser appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
                //ConfirmCode = x
            };
            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    //EmailUtility.SendEmail(model, x);
                    TempData["code"] = appUser.UserName;
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Şifreler Eşleşmiyor.");
            }
            return View();
        }
    }
}