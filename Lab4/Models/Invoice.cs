using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string OrganizationName { get; set; }
        public List<Product> Products { get; set; }
        public decimal TotalSum { get; set; }

        public Invoice(int Id, DateTime Date, string OrganizationName, List<Product> Products)
        {
            this.Id = Id;
            this.Date = Date;
            this.OrganizationName = OrganizationName;
            this.Products = Products;

            foreach (var product in Products)
            {
                TotalSum += product.Total;
            }
        }
    }
}
