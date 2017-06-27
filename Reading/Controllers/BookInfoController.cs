using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class BookInfoController : Controller
    {
        private ReadingContext db = new ReadingContext();
        // GET: BookInfo


        public ActionResult ReadBook(int? id)
        {
            /* id = 1;*///假设
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            /* Chapter  c = db.Chapters.Find(id); *///select *from Chapters where Books_bookId=1 and chaptername=1
            Chapter c = db.Chapters.Single(a => a.Books.bookId == id && a.chapterName == 1);
            //Chapter x=db.Chapters .Where (a => a.Books.bookId == id)
            //c.Books.bookId =(int) id;
            //int b = c.Books.bookId;//通过书的id来找章节
            //db.Chapters.Find();
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }
        // GET: Movies/Edit/5
        public ActionResult ShowBookInfo(int? id)
        {
            id = 1;//假设

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Book book = db.Books.Find(id);
            Session["bookName"] = book.bookName;
            Session["author"] = book.author;
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        public ActionResult Index(string SearchString)
        {
            //var a=Request.QueryString["SearchString"].ToString();

            //1、查询出Movies表里的所有数据
            var books = from m in db.Books
                         select m;
            //构造一个数据集，把数据传递给View里的下拉列表控件
            var genrelst = new List<string>();
            var genreQry = from d in books
                           orderby d.bookName
                           select d.bookName;
            //使用addRang函数把一个数组的所有元素添加到列表的末尾
            genrelst.AddRange(genreQry.Distinct());

            //把检索好的数据集绑定到页面的dropdownlist控件里
            ViewBag.mGenreData = new SelectList(genrelst);

                if (!String.IsNullOrEmpty(SearchString))
                {
                    //精准查询 
                    //movies = movies.Where(c => c.Title==SearchString);
                    //模糊查询
                    books  = books.Where(c => c.bookName .Contains(SearchString));

                }
              
           

            return View(books);

        }
        public ActionResult Create(int? id)
        {
            if (ModelState.IsValid)
            {
                if (Session["UserId"] == null)
                {
                    return RedirectToAction("Login", "Login");
                }
                //id = 1;
                //ViewBag.UserId = 1;
                Bookshelves bs = new Bookshelves();
                Book b = db.Books.Find(1);
                User u = db.Users.Find(Session["UserId"]);
                //bs.Books.bookId = new int();
                //bs.Books.bookId =1;
                bs.Books = b;
                bs.Users = u;
                //bs.Users.userId = ViewBag.UserId;
                db.Bookshelves.Add(bs);
                db.SaveChanges();
                return Content("已经添加入书架！");

            }
            return RedirectToAction("Personal", "Personal");


        }
    }
}