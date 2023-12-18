using System.Collections.ObjectModel;


namespace Lab4.Models
{
    public static class InvoiceManager
    {
        public static ObservableCollection<Invoice> Invoices = new ObservableCollection<Invoice>();

        public static ObservableCollection<Invoice> GetInvoices() 
        { 
            return Invoices; 
        }

        public static void AddInvoice(Invoice invoice)
        {
            Invoices.Add(invoice);
        }

    }
}
