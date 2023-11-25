using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab4.Commands;
using System.Windows;
using Lab4.Models;
using Lab4.jsonParse;
using System.Collections.ObjectModel;

namespace Lab4.ViewModels
{
    public class InvoiceCreateWindowVM : ViewModelBase
    {
        public string organizationName { get; set; }
        public DateTime dateOfCreation { get; set; }
        public ObservableCollection<InvoiceType> invoiceTypes { get; set; }
        public string countOfProducts { get; set; }

        public InvoiceType selectedInvoiceType { get; set; }

        private ICommand openFillingInvoiceWindowCommand;

        public InvoiceCreateWindowVM()
        {
            invoiceTypes = FileConnect.invoicesTypes.invoicesTypes;
        }

        public ICommand OpenFillingInvoiceWindowCommand
        {
            get
            {
                if (openFillingInvoiceWindowCommand == null)
                {
                    openFillingInvoiceWindowCommand = new RelayCommand(OpenFillingInvoiceWindow);
                }
                return openFillingInvoiceWindowCommand;
            }
        }
        private void OpenFillingInvoiceWindow()
        {
            if (organizationName == null)
            FillingInvoiceWindow fillingInvoiceWindow = new FillingInvoiceWindow();
            fillingInvoiceWindow.DataContext = new FillingInvoiceWindowVM(organizationName, selectedInvoiceType, countOfProducts, dateOfCreation);
            fillingInvoiceWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            fillingInvoiceWindow.Show();
        }
    }
}
