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
    /// Interaction logic for _1_LoginMerchant.xaml
    /// </summary>
    public partial class _1_LoginMerchant : Page
    {
        public _1_LoginMerchant()
        {
            InitializeComponent();
            AccessToken.Text = "A103.rzFVkJfkr0MvAKqA5md2etSMP9BM0zyiyE4UilSgaJKM2Vi0rCT4eD4wSU_D6MNw.w8F7NwiizxWDhnrReUZuNvzC2Yy";
            Stage.Text = "stage2d0083";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;
            var credentials = new SdkCredentials(Stage.Text, AccessToken.Text, "production");
            credentials.SetTokenRefreshCredentials(
                "D103.Fo7Hx-279X_WDuUP5Q2WNaNYJAN91lPqVQ8bb-lSbuw.v544vZaYLZUcN33Vh_-bQa6v-yC", "PPHAccreditron9k",
                "A8VERY8SECRET8VALUE0");
            var merchant = await RetailSDK.InitializeMerchant(credentials);
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
