using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IActionResult Index()
        {
            var values = _contentService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddContent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContent(Content content)
        {
            _contentService.TInsert(content);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteContent(int id)
        {
            var value = _contentService.TGetById(id);
            _contentService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateContent(int id)
        {
            var value = _contentService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateContent(Content content)
        {
            _contentService.TUpdate(content);
            return RedirectToAction("Index");

        }

        public ActionResult ContentByHeading(int id = 0)
        {
            var values = _contentService.GetListByHeadingID(id);
            return View(values);
        }
        public ActionResult ContentByHeadingWriter(int id = 0)
        {
            var values = _contentService.GetListByHeadingID(id);
            return View(values);
        }
    }
}
