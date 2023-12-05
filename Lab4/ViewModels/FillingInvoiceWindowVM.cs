using Lab4.Commands;
using Lab4.jsonParse;
using Lab4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Lab4.ViewModels
{
    public class FillingInvoiceWindowVM : ViewModelBase
    {
        public string OrganizationName { get; }
        public string InvoiceTypeName { get; }
        public int CountOfProducts { get; }
        public string DateOfCreation { get; }

        public List<string> ProductList { get; set; }
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private ICommand _addInvoice;
        private ICommand _calculateSum;
        private decimal _totalSum  = 0;

        public decimal TotalSum
        {
            get { return _totalSum; }
            set
            {
                if (_totalSum != value)
                {
                    _totalSum = value;
                    OnPropertyChanged(nameof(TotalSum));
                }
            }
        }

        public ICommand CalculateSumCommand
        {
            get
            {
                if (_calculateSum == null)
                {
                    _calculateSum = new RelayCommand(calculateSum);
                }
                return _calculateSum;
            }
        }

        public ICommand AddInvoiceCommand
        {
            get
            {
                if (_addInvoice == null)
                {
                    _addInvoice = new RelayCommand(AddInvoice);
                }
                return (_addInvoice);
            }
        }

        public FillingInvoiceWindowVM(string OrganizationName, InvoiceType InvoiceType, int CountOfProducts, DateTime dateTime)
        {
            this.OrganizationName = OrganizationName;
            this.InvoiceTypeName = InvoiceType.invoiceTypeName;
            this.ProductList = InvoiceType.productList;
            this.CountOfProducts = CountOfProducts;
            this.DateOfCreation = dateTime.ToShortDateString();
            
            for (int i = 0; i < this.CountOfProducts; i++)
            {
                Products.Add(new Product());
            }
        }

        private void calculateSum()
        {
            decimal sum = 0;
            foreach (Product product in Products)
            {
                sum += product.Quantity * product.Price;
            }
            this.TotalSum = sum;
        }

        private void AddInvoice()
        {
            bool flag = true;
            foreach (Product product in Products)
            {
                if (product.Name == null || product.Quantity == 0 || product.Price == 0)
                {
                    MessageBox.Show("Заполните все поля");
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                Invoice invoice = new Invoice(DateOfCreation, OrganizationName, Products, TotalSum);
                InvoiceManager.AddInvoice(invoice);
                Window window = Application.Current.Windows.OfType<FillingInvoiceWindow>().FirstOrDefault();
                window.Close();
            }
        }
    }
}
