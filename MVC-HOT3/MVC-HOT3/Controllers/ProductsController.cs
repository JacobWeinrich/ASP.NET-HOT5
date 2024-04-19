using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_HOT3.Models;

namespace MVC_HOT3.Controllers
{
    public class ProductsController : Controller
    {
        public TechStoreContext Context { get; set; }

        public ProductsController(TechStoreContext ctx)
        {
            Context = ctx;
        }


        [HttpGet]
        [Route("/products")]
        public IActionResult List()
        {
            if (TempData.Peek("message") != null)
            {
                ViewData["TempMessage"] = TempData["message"];
            }
            var phones = Context.Phones.Include(o => o.PhoneOs).OrderBy(t => t.PhoneBrand).ToList();
            return View(phones);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("List", "Products");
        }
    }
}
