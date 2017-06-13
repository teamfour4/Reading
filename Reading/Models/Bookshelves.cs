using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reading.Models
{
    public class Bookshelves
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自动增长
        public int bookshelvesId { get; set; }

        //public int bookId { get; set; }

        //public string userId { get; set; }
        public virtual User Users { get; set; }
        public virtual Book Books { get; set; }
    }
}