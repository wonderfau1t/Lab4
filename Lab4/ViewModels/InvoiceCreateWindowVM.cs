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
            InvoiceTypes = new ObservableCollection<InvoiceType>(FileConnect.invoicesTypes);
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
            if (OrganizationName == null || SelectedInvoiceType == null || CountOfProducts == null || DateOfCreation == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else if (int.TryParse(CountOfProducts, out int result)) {
                if (result <= 0)
                {
                    MessageBox.Show("Количество товаров должно быть больше 0");
                    return;
                }
                FillingInvoiceWindow fillingInvoiceWindow = new FillingInvoiceWindow();
                fillingInvoiceWindow.DataContext = new FillingInvoiceWindowVM(OrganizationName, SelectedInvoiceType, result, DateOfCreation);
                fillingInvoiceWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                fillingInvoiceWindow.Show();
            }
            else
            {
                MessageBox.Show("Количество товаров должно быть числом");
            }
            
        }
    }
}
