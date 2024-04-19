using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_HOT3.Areas.Admin.Views.Models;
using MVC_HOT3.Models;
using System.Numerics;

namespace MVC_HOT3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductsController : Controller
    {
        public TechStoreContext Context { get; set; }

        public ProductsController(TechStoreContext ctx)
        {
            Context = ctx;
        }


        [HttpGet]
        [Route("/admin/products")]

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

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            var phone = new Phone();
            phone.PhoneImageName = "Phone.png";
            var vm = new EditAddViewModel
            {
                Phone = phone,
                PhoneOSs = Context.PhoneOs.ToList()
            };

            return View("AddEdit", vm);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var phone = Context.Phones.Find(id);
            var vm = new EditAddViewModel
            {
                Phone = phone,
                PhoneOSs = Context.PhoneOs.ToList()
            };
            return View("AddEdit", vm);
        }

        [HttpPost]
        public IActionResult AddEdit(Phone phone)
        {
            if (ModelState.IsValid)
            {
                if (phone.PhoneID == 0)
                {
                    Context.Phones.Add(phone);
                    TempData["message"] = $"{phone.PhoneName} has been Added";
                }
                else
                {
                    Context.Phones.Update(phone);
                    TempData["message"] = $"{phone.PhoneName} has been Updated";
                }
                Context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = (phone.PhoneID == 0) ? "Add" : "Edit";
                var vm = new EditAddViewModel
                {
                    Phone = phone,
                    PhoneOSs = Context.PhoneOs.ToList()
                };
                return View("AddEdit", vm);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Phone phone = Context.Phones.Include(o => o.PhoneOs).FirstOrDefault(p => p.PhoneID == id)!;
            return View("Delete", phone);
        }
        [HttpPost]
        public IActionResult Delete(Phone phone)
        {
            Context.Phones.Remove(phone);
            Context.SaveChanges();
            TempData["message"] = $"{phone.PhoneName} has been Deleted";
            return RedirectToAction("List", "Products");
        }

    }
}
