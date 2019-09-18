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
using MWRDemoDll;

namespace MRDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MifareRFEYE Mir;
        public MainWindow()
        {
            InitializeComponent();
            Mir = MifareRFEYE.Instance;
        }
        /// <summary>
        /// 连接高频读写器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var CardInfo = Mir.ConnDevice();
            //下面判断可有可无
            if (CardInfo.Result == Result.Success)
            {
                textBox.Text += "连接成功" + "\n";
            }
            else
            {
                textBox.Text += "连接失败" + "\n";
            }

        }

        /// <summary>
        /// 向扇区写卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            double xr = Convert.ToDouble(Mir.ReadString(CardDataKind.Data1, 1))+ Convert.ToDouble(textBox1.Text);
            Mir.WriteString(CardDataKind.Data1, Convert.ToString(xr), 1);
        }

        /// <summary>
        /// 向扇区查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Mir.Search();
            textBox.Text += Mir.ReadString(CardDataKind.Data1, 1) + "\n";
        }
    }
}
