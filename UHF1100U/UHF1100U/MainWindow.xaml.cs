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
using Srr1100U;

namespace UHF1100U
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        SrrReader srr;


        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
                srr = new SrrReader("COM4");
                int ConnDevice = srr.ConnDevice();
                switch (ConnDevice)
                {
                    case 0:
                        textBox.Text += "串口打开成功" + "\n";
                        break;
                    case -1:
                        textBox.Text += "串口传递错误" + "\n";
                        break;
                    case -2:
                        textBox.Text += "串口打开失败" + "\n";
                        break;
                    case -3:
                        textBox.Text += "程序错误" + "\n";
                        break;
                    default:
                        this.Close();
                        break;
                }
        }


        /// <summary>
        /// 创建线程读取标签
        /// </summary>
        /// <param name="rfid"></param>
        private void hd(string rfid)
        {
            Dispatcher.Invoke(() =>
            {
                if (!textBox.Text.Contains(rfid))
                    textBox.Text += rfid + "\n";
            });
        }



        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
                srr.Read(hd);
        }


        /// <summary>
        /// 停止读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            srr.CloseDevice();
        }
    }
}
