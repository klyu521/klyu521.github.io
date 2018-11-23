using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace hw7.Models
{
   
   public class LogData
    {
       
        [Key]
        [Required]
        public int ID { get; set; }

   
        [Required]
        public String IPAddress { get; set; }

       
        [Required]
        public String Request { get; set; }

        
        [Required]
        public String ClientBrowser { get; set; }

        
        [Required]
        public DateTime AccessTime { get; set; } = DateTime.Now;
    }
}