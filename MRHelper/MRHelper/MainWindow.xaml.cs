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
using WMRHelper;

namespace MRHelper
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
        /// <summary>
        /// 连接高频读写器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //连接读写器
            var opencare = MifareRFEYE.Instance.ConnDevice();
            //下面判断语句可有可无，
            if (opencare.Status == ResultStatus.Success)
                textBox.Text += "连接成功" + "\n";
            else
                textBox.Text += "连接失败" + "\n";
        }
        /// <summary>
        /// 使用高频读写器读卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //寻卡
            var cardInfo = MifareRFEYE.Instance.Search();
            if (cardInfo.Status == ResultStatus.Success)
                textBox.Text += "卡号：" + cardInfo.AppendData + "\n";
            else
                textBox.Text += "读卡失败" + cardInfo.ErrorData + "\n";
        }
        /// <summary>
        /// 写入扇区数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (MifareRFEYE.Instance.ReadString(CardDataKind.Data) != null)
            {
                double cxye = Convert.ToDouble(MifareRFEYE.Instance.ReadString(CardDataKind.Data));
                cxye += Convert.ToDouble(textBox1.Text);
                MifareRFEYE.Instance.WriteString(CardDataKind.Data, Convert.ToString(cxye));
            }
            else
            {
                MifareRFEYE.Instance.WriteString(CardDataKind.Data, textBox1.Text);
            }
        }
        /// <summary>
        /// 查询扇区数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            string dk = MifareRFEYE.Instance.ReadString(CardDataKind.Data);
            textBox.Text += "卡内余额：" + dk + "\n";
        }
    }
}
