using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVC_HOT3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
