using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_HOT3.Models.Identity;

namespace MVC_HOT3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AccountManagerController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private RoleManager<IdentityRole> roleManager;

        public AccountManagerController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [Route("/admin/accountmanager")]
        public async Task<IActionResult> ManageUsers()
        {
            List<User> users = new List<User>();
            foreach (var u in userManager.Users)
            {
                u.RoleNames = await userManager.GetRolesAsync(u);
                users.Add(u);
            }

            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                TempData["message"] = "Admin role does not exist";
            }
            else
            {
                User user = await userManager.FindByIdAsync(id);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            }
            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            await userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " ";
                    }
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("Index");
        }
    }
}
