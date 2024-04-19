using Microsoft.AspNetCore.Mvc;
using MVC_HOT3.Models;
using System.Diagnostics;

namespace MVC_HOT3.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            ViewData["TempMessage"] = TempData["message"];
            return View();
        }


    }
}
