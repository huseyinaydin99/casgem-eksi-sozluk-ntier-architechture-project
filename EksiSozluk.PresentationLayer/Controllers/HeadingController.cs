using EksiSozluk.BusinessLayer.Abstract;
using EksiSozluk.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EksiSozluk.PresentationLayer.Controllers
{
    public class HeadingController : Controller
    {
        private readonly IHeadingService _headingService;
    

        public HeadingController(IHeadingService headingService)
        {
            _headingService = headingService;
            
        }

        public IActionResult Index()
        {
            var values = _headingService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddHeading()
        {
     
            return View();
        }

        [HttpPost]
        public IActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            _headingService.TInsert(heading);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHeading(int id)
        {
            var value = _headingService.TGetById(id);
            _headingService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateHeading(int id)
        {
            var value = _headingService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateHeading(Heading heading)
        {
            _headingService.TUpdate(heading);
            return RedirectToAction("Index");

        }


        [HttpGet("{id}")]
        public IActionResult GetHeading(int id)    
        {
            var value = _headingService.TGetById(id);
            return Ok(value);

        }


        public IActionResult HeadingList(int id)
        {
            List<Heading> values = _headingService.GetListByCategory(id);
            return View(values);
        }
    }
}
