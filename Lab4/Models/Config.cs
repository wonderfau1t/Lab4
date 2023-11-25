using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class TypeOfInvoice
    {
        public int ID { get; set; }
        public string typeOfInvoice;
        public List<string> productList;
    }
}
