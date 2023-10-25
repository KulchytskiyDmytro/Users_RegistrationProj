using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
        {
            string result = "Нема шляху";
            if (User.Identity.IsAuthenticated)
            {
                result = User.Identity.Name;
            }
            ViewBag.Login = result;
            
            List<User> users;
            using (UserContext db = new UserContext())
            {
                users = await db.Users.Include(user => user.Region).ToListAsync();
            }
            return View(users);
        }
        
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}