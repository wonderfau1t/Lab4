using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class InvoicesTypes
    {
        public ObservableCollection<InvoiceType> invoicesTypes { get; set; }
    }
    public class InvoiceType
    {
        public string invoiceTypeName { get; set; }
        public List<string> productList { get; set; }
    }
}
