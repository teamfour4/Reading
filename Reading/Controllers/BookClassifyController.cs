using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class BookClassifyController : Controller
    {
        // GET: BookClassify
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FantasyBook()//玄幻分类
        {
            return View();
        }
        public ActionResult EmpriseBook()//武侠分类
        {
            return View();
        }
        public ActionResult MetropolisBook()//都市分类
        {
            return View();
        }
        public ActionResult HistoryBook()//历史分类
        {
            return View();
        }
        public ActionResult GameBook()//游戏分类
        {
            return View();
        }
        public ActionResult ScifiBook()//科幻分类
        {
            return View();
        }
    }
}