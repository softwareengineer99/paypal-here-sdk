using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Wpf.SampleApp.SDK.Steps.Utils;

namespace Wpf.SampleApp.SDK.Steps
{
    /// <summary>
    /// Interaction logic for _2_DiscoveredDevices.xaml
    /// </summary>
    public partial class _2_DiscoveredDevices : Page
    {
        public _2_DiscoveredDevices()
        {
            InitializeComponent();
            DataGridDevices.ItemsSource = GetDiscoveredDevices();
            DataGridDevices.Items.Refresh();

            var timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            DataGridDevices.ItemsSource = GetDiscoveredDevices();
            DataGridDevices.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new _3_TakePayment());
        }

        private IEnumerable<Device> GetDiscoveredDevices()
        {
            return StateManager.Instance.Devices.Select(pd => new Device {SerialNumber = pd.Id, IsConnected = pd.IsConnected()}).ToList();
        }
    }

    public class Device
    {
        public string SerialNumber { get; set; }

        public bool IsConnected { get; set; }
    }
}
