using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Lab4.ViewModels;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class InvoiceCreateWindow : Window
    {
        public InvoiceCreateWindow()
        {
            InitializeComponent();
            DataContext = new InvoiceCreateWindowVM();
        }
    }
}
