using System.Collections.ObjectModel;


namespace Lab4.Models
{
    public class Invoice
    {
        public string Date { get; set; }
        public string OrganizationName { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        public decimal TotalSum { get; set; }

        public Invoice(string Date, string OrganizationName, ObservableCollection<Product> Products, decimal totalSum)
        {
            this.Date = Date;
            this.OrganizationName = OrganizationName;
            this.Products = Products;
            this.TotalSum = totalSum;
        }
    }
}
