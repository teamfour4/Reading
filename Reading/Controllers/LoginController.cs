using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class LoginController : Controller
    {

        private ReadingContext db = new ReadingContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(string userId, string password, string returnUrl)
        {



            if (!ValidataUser(userId, password))
            {
                Session["Exception"] = "用户名或密码错误！";
                return RedirectToAction("Login", "Login");
                //FormsAuthentication.SetAuthCookie(Email ,false );

            }
            if (String.IsNullOrEmpty(returnUrl))
            {
                return RedirectToAction("HomePage", "HomePage");
            }
            else
            {
                return Redirect(returnUrl);
            }
            //ModelState.AddModelError("", "您输入的账号密码错误");

        }
       
        public bool ValidataUser(string UserId, string Password)
        {
            //根据传入的Email和password的值进行检索
            var users = db.Users.FirstOrDefault(u => u.userId == UserId && u.password == Password);
            if (users != null)
            {
                Session["userId"] = UserId;
                //Session["Role"] = member.roles.Name;

                return true;
            }

            return false;
        }
    }
}