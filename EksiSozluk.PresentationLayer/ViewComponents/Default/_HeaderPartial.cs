using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.ViewComponents.Default
{
    public class _HeaderPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
