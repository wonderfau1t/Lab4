using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class InvoiceManager
    {
        public ObservableCollection<Invoice> Invoices = new ObservableCollection<Invoice>();

        public ObservableCollection<Invoice> GetInvoices() 
        { 
            return Invoices; 
        }

        public void AddInvoice(Invoice invoice)
        {
            Invoices.Add(invoice);
        }

    }
}
