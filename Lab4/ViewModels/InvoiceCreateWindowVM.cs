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
        public string OrganizationName { get; set; }
        public DateTime DateOfCreation { get; set; }
        public ObservableCollection<InvoiceType> InvoiceTypes { get; set; }
        public string CountOfProducts { get; set; }

        public InvoiceType SelectedInvoiceType { get; set; }

        private ICommand openFillingInvoiceWindowCommand;

        public InvoiceCreateWindowVM()
        {
            InvoiceTypes = FileConnect.invoicesTypes.invoicesTypes;
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
            if (int.TryParse(CountOfProducts, out int result) {

            }
            FillingInvoiceWindow fillingInvoiceWindow = new FillingInvoiceWindow();
            fillingInvoiceWindow.DataContext = new FillingInvoiceWindowVM(OrganizationName, SelectedInvoiceType, CountOfProducts, DateOfCreation);
            fillingInvoiceWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            fillingInvoiceWindow.Show();
        }
    }
}
