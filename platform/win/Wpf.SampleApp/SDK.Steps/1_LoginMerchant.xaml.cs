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

namespace Wpf.SampleApp.SDK.Steps
{
    /// <summary>
    /// Interaction logic for _1_LoginMerchant.xaml
    /// </summary>
    public partial class _1_LoginMerchant : Page
    {
        public _1_LoginMerchant()
        {
            InitializeComponent();
            AccessToken.Text = "A103._Hpo5hP9fNZmB_FYbSB7fQfh2S_ogx7qIR9EYFvY3OK68NKVcNpJLSTxVKidXx6F.8Wzaf-PJKIcSbjBzk8ZtYqyWB7G";
            Stage.Text = "stage2d0044";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var merchant = await RetailSDK.InitializeMerchant(new SdkCredentials(Stage.Text, AccessToken.Text));
            StateManager.Instance.ActiveMerchant = merchant;
            Mouse.OverrideCursor = null;
            NavigationService.Navigate(new _2_DiscoveredDevices());
        }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var tb = (sender as TextBox);
            if (tb == null)
            {
                return;
            }

            if (tb.IsKeyboardFocusWithin) return;
            tb.SelectAll();
            e.Handled = true;
            tb.Focus();
        }
    }
}
