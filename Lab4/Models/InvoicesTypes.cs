using System.Collections.Generic;

namespace Lab4.Models
{
    public class InvoiceType
    {
        public string InvoiceTypeName { get; set; }
        public List<string> ProductList { get; set; }
    }
}
