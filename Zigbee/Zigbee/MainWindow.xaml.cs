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
using NLE.Device.ZigBee;

namespace Zigbee
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        ZigBeeSeries Zigbee = new ZigBeeSeries("COM3");
        public MainWindow()
        {
            InitializeComponent();
            Zigbee.Connect();
        }

        private void Zigbee_DataReceived(object sender, ZigBeeDataEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                textBox.Text += string.Format("{0},{1},{2},{3},{4}", e.Data.Type, e.Data.Value1, e.Data.Value2, e.Data.Value3, e.Data.Value4);
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Zigbee.DataReceived += Zigbee_DataReceived;
        }
    }
}
