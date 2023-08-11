using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}