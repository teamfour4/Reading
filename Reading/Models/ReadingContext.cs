using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Reading.Models
{
    public class ReadingContext:DbContext
    {
        public ReadingContext()
            : base("name=ReadingDbConnetion")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Bookshelves> Bookshelves { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
    }
}