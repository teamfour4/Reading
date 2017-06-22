using Reading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Reading.Controllers
{
    public class BookInfoController : Controller
    {
        private ReadingContext db = new ReadingContext();
        // GET: BookInfo
      

        public ActionResult ShowBookInfo()
        {
            return View();
        }

        public ActionResult ReadBook()
        {
            return View();
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
    }
}