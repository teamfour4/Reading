using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reading.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自动增长
        public int bookId { get; set; }//编号
        [DisplayName("书名")]
        public string bookName { get; set; }//书名
        [DisplayName("作者")]
        public string author { get; set; }//作者
        [DisplayName("简介")]
        public string introduction { get; set; }//简介
        [DisplayName("分类")]
        public string classify { get; set; }//分类

        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Bookshelves> Bookshelves { get; set; }
    }
}