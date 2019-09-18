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
using NLE.Device.LowFreq;

namespace LowFreq
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        LowFreqReader freqReader;

        public MainWindow()
        {
            InitializeComponent();
            freqReader = new LowFreqReader("COM4");
        }


        /// <summary>
        /// 连接低频读写器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            freqReader.Open();
        }


        /// <summary>
        /// 读取低频卡号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text += freqReader.ReadData();
        }
    }
}
