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
using Wpf.SampleApp.SDK.Steps.Utils;
using Page = System.Windows.Controls.Page;

namespace Wpf.SampleApp.SDK.Steps
{
    /// <summary>
    /// Interaction logic for _0_Initialize.xaml
    /// </summary>
    public partial class _0_Initialize : Page
    {
        public _0_Initialize()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            RetailSDK.Initialize();
            StateManager.Instance.ListenForDevices();
            Mouse.OverrideCursor = null;
            NavigationService.Navigate(new _1_LoginMerchant());
        }
    }
}
