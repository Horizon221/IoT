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
using NLECloudSDK.Model;
using NLECloudSDK;
using Newtonsoft.Json;

namespace Cloud
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        NLECloudAPI SDK;
        string Token;
        dynamic Data;
        AccountLoginDTO dTO = new AccountLoginDTO();
        public MainWindow()
        {
            InitializeComponent();
            SDK = new NLECloudAPI("http://api.nlecloud.com");
            dTO.Account = ID.Text;
            dTO.Password = Psw.Text;
        }
        private string Json(object reade)
        {
            return JsonConvert.SerializeObject(reade);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Data = SDK.UserLogin(dTO);
            Token = Data.ResultObj.AccessToken;
            textBox.Text += "登录返回Token:" + "\n" + Token+"\r\n";
            Data = SDK.GetSensorInfo(Convert.ToInt32(sbid.Text), sbbs.Text, Token);
            textBox.Text += Data.ResultObj.Value + Data.ResultObj.Unit;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (button1.Content.Equals("开"))
            {
                textBox.Text += Json(SDK.Cmds(Convert.ToInt32(sbid.Text), zlbs.Text, 1, Token));
                button1.Content = "关";
            }
            else
            {
                textBox.Text += Json(SDK.Cmds(Convert.ToInt32(sbid.Text), zlbs.Text, 0, Token));
                button1.Content = "开";
            }
            
        }
    }
}
