using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewListing.Models
{

    public class Users
    {
        public virtual int user_id { get; set; }
        public virtual string username { get; set; }
        public virtual string email { get; set; }
        public virtual string password { get; set; }
        //public virtual ISet<Tasks> Task { get; set; }
    }

  
}