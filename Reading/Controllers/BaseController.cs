using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public ActionResult Index()
        {
            return View();
        }

        protected List<Bookshelves> Bookshelves
        {
            get
            {
                if (Session["Bookshelves"] == null)
                {
                    Session["Bookshelves"] = new List<Bookshelves>();//如果为空，则对购物车初始化

                }
                //返回当前购物车
                return (Session["Bookshelves"] as List<Bookshelves>);

            }
            set
            {
                Session["Bookshelves"] = value;


            }
        }

    }

    }