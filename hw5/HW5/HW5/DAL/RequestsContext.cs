using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class RequestsContext :  DbContext
    {
        public RequestsContext() : base("name=Requests") { }
        public virtual DbSet<Requests> Requests { get; set; }
    }
}
