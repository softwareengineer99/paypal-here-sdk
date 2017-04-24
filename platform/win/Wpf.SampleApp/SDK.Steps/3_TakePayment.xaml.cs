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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PayPalRetailSDK;
using Page = System.Windows.Controls.Page;

namespace Wpf.SampleApp.SDK.Steps
{
    /// <summary>
    /// Interaction logic for _3_TakePayment.xaml
    /// </summary>
    public partial class _3_TakePayment : Page
    {
        public _3_TakePayment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            decimal amount, tip;
            amount = decimal.TryParse(AmountField.Text, out amount) ? amount : 1;
            tip = decimal.TryParse(GratuityField.Text, out tip) ? tip : 0;

            var invoice = new Invoice(null);
            invoice.AddItem("Amount", decimal.One, amount, "", "");
            if (tip > 0)
            {
                invoice.GratuityAmount = tip;
            }

            RetailSDK.WpfContentGridForUi = (Grid)Content;
            var transaction = RetailSDK.CreateTransaction(invoice);
            transaction.Begin();
        }
    }
}
