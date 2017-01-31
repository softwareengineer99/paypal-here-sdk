using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPalRetailSDK;

namespace Wpf.SampleApp.SDK.Steps.Utils
{
    internal class StateManager
    {
        private static StateManager _state;

        private StateManager()
        {
            Devices = new List<PaymentDevice>();
        }

        public static StateManager Instance => _state ?? (_state = new StateManager());

        public Merchant ActiveMerchant { get; set; }

        public List<PaymentDevice> Devices { get; set; }

        public void ListenForDevices()
        {
            RetailSDK.DeviceDiscovered += (sender, device) =>
            {
                Devices.Add(device);
            };
        }
    }
}
