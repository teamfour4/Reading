using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class BookController : Controller
    {
        private ReadingContext db = new ReadingContext();
        // GET: Book
        public ActionResult Index()
        {
            return View(db.Books .ToList());
        }


    }
}