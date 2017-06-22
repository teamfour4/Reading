﻿using Reading.Models;
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
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult ShowBookInfo()
        //{
        //    return View();

        //}

        public ActionResult ReadBook()
        {
            return View();
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
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Movies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ShowBookInfo([Bind(Include = "bookId,bookName,RealeaseDate,Genre,Price,Rating")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(book).State = System.Data.Entity.EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(book);
        //}
    }
}