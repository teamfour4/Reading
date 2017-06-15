using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class RegisterController : Controller
    {
        private ReadingContext db = new ReadingContext();
        // GET: Member
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection fc, User user)
        {
            var cnk_user = db.Users.FirstOrDefault(p => p.userId == user.userId);
            if (cnk_user != null)
            {
                ModelState.AddModelError("userId", "该用户名已被注册！");
                return View();
            }
            user.password = fc["password"].ToString().Trim();
          if(ModelState .IsValid )
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login","Login");
            }
            return View();
        }
    }
}