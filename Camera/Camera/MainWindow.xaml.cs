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
using Camera.Net;

namespace Camera
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        CameraCapture camera;
        CameraPTZ cameraPTZ;


        /// <summary>
        /// 摄像头属性
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            camera = new CameraCapture();
            cameraPTZ = new CameraPTZ();
            cameraPTZ.Host = "192.168.1.245";
            cameraPTZ.Port = 80;
            cameraPTZ.UserName = "admin";
            cameraPTZ.Password = "admin";
            cameraPTZ.Args = "/web/cgi-bin/hi3510/ptzctrl.cgi?-step=0&-act=[PTZ]";
        }


        /// <summary>
        /// 打开摄像头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            camera.Open("rtsp://admin:admin@192.168.1.245/11");
            camera.OnFrameChanged += xc;
        }


        /// <summary>
        /// 创建线程获取摄像头流
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="buffer"></param>
        private void xc(object sender, byte[] buffer)
        {
            Dispatcher.Invoke(() =>
            {
                image.Source = WpfApplication1.BitmapConvert.ToBitmapImage(buffer);
            });
        }


        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            cameraPTZ.TurnLeft();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            cameraPTZ.TurnRight();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            cameraPTZ.TurnUp();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            cameraPTZ.TurnDown();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            camera.Close();
        }
    }
}
