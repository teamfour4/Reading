using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class BookInfoController : Controller
    {
        // GET: BookInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowBookInfo()
        {
            return View();
        }

        public ActionResult ReadBook()
        {
            return View();
        }
    }
}