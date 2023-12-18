using System.Windows.Input;
using System.Windows;
using Lab4.Commands;
using Lab4.Models;
using System.Collections.ObjectModel;

namespace Lab4.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        public ObservableCollection<Invoice> Invoices { get; set; }
        private ICommand openInvoiceCreateWindowCommand;

        private bool isInvoiceCreateWindowOpen = false;

        public ICommand OpenInvoiceCreateWindowCommand
        {
            get
            {
                if (openInvoiceCreateWindowCommand == null)
                {
                    openInvoiceCreateWindowCommand = new RelayCommand(OpenInvoiceCreateWindow);
                }
                return openInvoiceCreateWindowCommand;
            }
        }

        private void OpenInvoiceCreateWindow()
        {
            if (!isInvoiceCreateWindowOpen)
            {
                InvoiceCreateWindow invoiceCreateWindow = new InvoiceCreateWindow();
                invoiceCreateWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                invoiceCreateWindow.Closed += (sender, e) => { isInvoiceCreateWindowOpen = false; };
                invoiceCreateWindow.Show();

                isInvoiceCreateWindowOpen = true;
            }
        }

        public MainWindowVM()
        {
            Invoices = InvoiceManager.GetInvoices();
        }
    }
}
