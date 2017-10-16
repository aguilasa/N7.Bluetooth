using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bluetooth
{
    public partial class MainPage : ContentPage
    {
        IBluetoothLE ble;
        IAdapter adapter;
        public MainPage()
        {
            InitializeComponent();

            ble = CrossBluetoothLE.Current;
            adapter = CrossBluetoothLE.Current.Adapter;
            deviceList = new ObservableCollection<IDevice>();
            lv.ItemsSource = deviceList;

        }

        private void btnStatus_Clicked(object sender, EventArgs e)
        {
            var state = ble.State;
            this.DisplayAlert("AVISO", state.ToString(), "OK");
        }

        ObservableCollection<IDevice> deviceList;
        IDevice device;

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            deviceList.Clear();

            adapter.DeviceDiscovered += (s, a) =>
            {   
                deviceList.Add(a.Device);
            };

            await adapter.StartScanningForDevicesAsync();
        }

        private void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}
