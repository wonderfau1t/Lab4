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
        public string organizationName { get; }
        public string invoiceTypeName { get; }
        public int countOfProducts { get; }
        public string dateOfCreation { get; }
        private decimal _totalSum  = 0;
        public decimal totalSum
        {
            get { return _totalSum; }
            set
            {
                if (_totalSum != value)
                {
                    _totalSum = value;
                    OnPropertyChanged(nameof(totalSum));
                }
            }
        }
        
        public List<string> _productList { get; set; }
        private ICommand _addInvoice;
        private ICommand _calculateSum;
        public ObservableCollection<Product> products { get; set; } = new ObservableCollection<Product>();
        public Product SelectedProduct { get; set; }

        public FillingInvoiceWindowVM(string organizationName, InvoiceType invoiceType, string countOfProducts, DateTime dateTime)
        {
            this.organizationName = organizationName;
            this.invoiceTypeName = invoiceType.invoiceTypeName;
            this._productList = invoiceType.productList;
            this.countOfProducts = Convert.ToInt32(countOfProducts);
            this.dateOfCreation = dateTime.ToShortDateString();
            
            for (int i = 0; i < this.countOfProducts; i++)
            {
                AddRow();
            }
        }

        private void AddRow()
        {
            products.Add(new Product());
        }

        public ICommand CalculateSumCommand
        {
            get {
                if (_calculateSum == null) 
                {
                    _calculateSum = new RelayCommand(calculateSum);
                }
                return _calculateSum;
            }
            
        }

        private void calculateSum()
        {
            decimal sum = 0;
            foreach (Product product in products)
            {
                sum += product.Quantity * product.Price;
            }
            this.totalSum = sum;
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

        private void AddInvoice()
        {
            Invoice invoice = new Invoice(dateOfCreation, organizationName, products, totalSum);
            InvoiceManager.AddInvoice(invoice);
            Window window = Application.Current.Windows.OfType<FillingInvoiceWindow>().FirstOrDefault();
            window.Close();
        }
    }
}
