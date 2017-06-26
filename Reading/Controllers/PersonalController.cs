using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class PersonalController : Controller
    {
        private ReadingContext db = new ReadingContext();
        // GET: Personal
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Personal()
        {
            return View();
        }
        //public ActionResult showCartInfo()
        //{
        //    return View(this.Carts);
        //}
    }
}