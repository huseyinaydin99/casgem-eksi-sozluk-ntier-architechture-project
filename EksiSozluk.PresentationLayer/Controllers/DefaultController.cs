using EksiSozluk.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            string user = HttpContext.Session.GetString("username");

            return View(new SessionViewModel { UserName = user});
        }
    }
}
