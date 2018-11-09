using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WideWorldImporters.Models.ViewModel
{
    public class Info
    { 
        public Person Person { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<InvoiceLine> InvoiceLine { get; set; }
    }
}
   