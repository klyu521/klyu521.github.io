using hw7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace hw7.DAL
{
    public class LogContext : DbContext
    {


        public LogContext() : base("name=Log")
        {

        }

        /// <summary>
        /// Tells you what you can do with the db whether to get information from it or set information in it. 
        /// </summary>
        public virtual DbSet<LogData> Log { get; set; }

    }
}
