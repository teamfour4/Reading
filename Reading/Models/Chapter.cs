using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reading.Models
{
    public class Chapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自动增长
        [DisplayName("章节编号")]
        public int chapterId { get; set; }
        //[DisplayName("书的编号")]
        //public int bookId { get; set; }
        [DisplayName("章节标题")]
        public string title { get; set; }
        [DisplayName("内容")]
        public string content { get; set; }
        public virtual Book Books { get; set; }
    }
}