using Reading.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult modUserPassword()
        {
            if(Session ["userId"]==null)
            {
                return RedirectToAction("Login","Login");
            }
            string userid = Session["userId"].ToString().Trim();
            var user = db.Users.FirstOrDefault(m=>m.userId ==userid);
            return View(user);
        }
        [HttpPost]
        public ActionResult modUserPassword(FormCollection fc,User user)
        {
            user = db.Users.FirstOrDefault(m => m.userId == user.userId);
            string txtpwd = fc["txtpassword"].ToString().Trim();
            string txtpwd1 = fc["txtPassword1"].ToString().Trim();
            if (!txtpwd.Equals(user.password))
            {
                Session["Execption"] = "输入的旧密码错误，请从新输入！";
                return RedirectToAction("modUserPassword", "Register");
            }

            user .password = txtpwd1;
            //members.roles = members.roles;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("HomePage", "HomePage");

        }
        }
}