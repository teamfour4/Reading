using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class PersonalController : BaseController
    {
        private ReadingContext db = new ReadingContext();
        // GET: Personal
        public ActionResult Index()
        {
            return View(this.Bookshelves);
        }

        [HttpPost]
        public ActionResult Personal1(int? id, int bookshelvesId = 1)
        {

            //检索嘉宾是否存在，如果不存在，则给出出错提示
            //id = Guid.Parse("");
            var Books = db.Books.Find(id);
            if (Books == null)
            {
                return HttpNotFound();
            }
            //如果这条记录，则添加到书架
            //书架中是否存在该记录，如果存在，则数量加1，否则直接添加一笔新的记录
            var exitst = this.Bookshelves.FirstOrDefault(m => m.bookshelvesId == id);//获取Session里面的值
            if (exitst != null)//如果不为空，直接数量加1
            {
                exitst.bookshelvesId += 1;

            }
            else
            {
                //this.Carts.Add(new Cart() { Products = product, Amount = Amount });
                Bookshelves c = new Bookshelves();
                c.Books = Books;//给对象赋值
                c.bookshelvesId = bookshelvesId;
                this.Bookshelves.Add(c);

            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.Created);

        }

        public ActionResult Personal()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            //id = 1;
            //ViewBag.UserId = 1;
            string ss = Session["UserId"].ToString();
            Bookshelves bs = new Bookshelves();
            var data2 = db.Bookshelves.OrderBy(m => m.bookshelvesId).ToList();
            var ff = data2.Where(a => a.Users.userId == ss).ToList();
            //var data = db.Bookshelves.Where (m => m.Users .userId ==((Session["UserId"])).ToString ()).ToList();
            //var aussieDestinations = from d in db .Bookshelves.Local
            //                   where d.Users .userId  == Session["UserId"]
            //                         select d;
            //Bookshelves books = db.Bookshelves.Where (a => a.Users.userId == Session["UserId"]);

            //Session["bookName"] = book.bookName;
            //Session["author"] = book.author;

            //Bookshelves x = db.Bookshelves.Where(a => a.Users.userId == Session["UserId"]);
            return View(ff);
        }


    }
}