using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web.Mvc;
using WebApplication8.Models;
using Region = System.Drawing.Region;

namespace WebApplication8.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name && u.Password == model.Password);
                    
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Користувач с таким email та паролем не зареєстрований");
                }
            }
 
            return View(model);
        }
        public async Task<ActionResult> Register()
        {
            List<Models.Region> regions;
            using (UserContext db = new UserContext())
            {
                regions = await db.Regions.ToListAsync();
            }
        
            ViewBag.Regions = regions;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Models.Models.RegisterModel model)
        {
            List<Models.Region> regions;
            using (UserContext db = new UserContext())
            {
                regions = await db.Regions.ToListAsync();
            }
        
            ViewBag.Regions = regions;
            
            if (!ModelState.IsValid) return View(model);
            
            User user = null;
            using (UserContext db = new UserContext())
            {
                user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            }
            if (user == null)
            {
                using (UserContext db = new UserContext())
                {
                    db.Users.Add(new User { Name = model.Name ,Email = model.Email, Password = model.Password, Age = model.Age, RegionId = int.Parse(model.RegionId), Phone = model.Phone});
                    await db.SaveChangesAsync();
 
                    user = await db.Users.FirstOrDefaultAsync(u => u.Name == model.Name && u.Password == model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Користувач с таким Email вже існує");
            }
            
            return View(model);
        }
    }
}