using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reading.Models
{
    public class User
    {
        [Key]
        [DisplayName("登录账号")]
        public string userId { get; set; }
        [DisplayName("登录密码")]
        public string password { get; set; }

        public virtual ICollection<Bookshelves> Bookshelves { get; set; }

    }
}