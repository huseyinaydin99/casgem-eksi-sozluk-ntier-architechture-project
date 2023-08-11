using EksiSozluk.EntityLayer.Concrete;
using EksiSozluk.PresentationLayer.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace EksiSozluk.PresentationLayer.Controllers
{
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
            int code = model.ConfirmCode;
            //ViewBag.username = TempData["username"].ToString();
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (code.ToString() == model.ConfirmCode.ToString())
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return Redirect("/Login/Index");
            }
            return View();
        }
    }
}