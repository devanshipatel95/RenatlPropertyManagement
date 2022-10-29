using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class AccountsController : Controller
    {

        private readonly FinalProjectContext _context = new FinalProjectContext();

        public IActionResult Register()
        {
            var finalProjectContext = _context.Users.Include(u => u.Role);
            ViewData["Role"] = new SelectList(_context.UserRoles, "UserRoleId", "Role");
            return View();
        }

        // GET: Account

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserId,UserName,Password,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }
            ViewData["RoleId"] = new SelectList(_context.UserRoles, "UserRoleId", "UserRoleId", user.RoleId);
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Users
                .Join(_context.UserRoles,
                us => us.RoleId,
                userRole => userRole.UserRoleId,
                (us, userRole) => new { us, userRole })
                .Where(x => x.us.UserName == user.UserName && x.us.Password == user.Password)
                .Select(result => new
                {
                    result.userRole.Role
                }).FirstOrDefault();

                if(check != null)
                {
                    HttpContext.Session.SetString("check", check.ToString());
                    return Redirect("~/Home/Index");
                }

            }
            ViewBag.ErrorMessage = "Invalid Credentials!!!";
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.SetString("check", " ");
            return Redirect("Login");
        }
    }
}
