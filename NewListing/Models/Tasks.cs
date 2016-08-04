using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewListing.Models
{
    public class Tasks
    {
        public virtual int task_id { get; set; }
        public virtual string task_desc { get; set; }
        public virtual bool state { get; set; }
        public virtual Users User { get; set; }
    }
}