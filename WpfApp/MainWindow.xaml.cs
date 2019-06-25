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
using System.Windows.Threading;
using WpfControlLibrary;

namespace WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private DispatcherTimer dispatcherTimer = new DispatcherTimer();
        UserControl1_Para userControl1_Para = new UserControl1_Para();
        CollectPoint collectPoint = new CollectPoint();
        double x = 0;
        double y = 0;
        public MainWindow()
        {
            InitializeComponent();
            //设置X轴参数
            userControl1_Para.xGrap = 2;//设置X轴相邻采集点的间隔
            userControl1_Para.xGrapLable = 100;//设置X轴时间标签的间隔
            userControl1_Para.xGrapLablePoint = userControl1_Para.xGrapLable/ userControl1_Para.xGrap;//相邻两个时间标签内有多少个采集点
            userControl1_Para.xWidth = 450;
            //设置Y轴参数
            userControl1_Para.yGrap = -10;
            userControl1_Para.yStartValue = 100;
            userControl1_Para.yGrapLable = 50;
            userControl1_Para.yLables = ((int)userControl.Height - 50) / userControl1_Para.yGrapLable;
            //设置控件参数
            userControl.myCanvasInit(userControl1_Para);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(100);//设置移动速度
            dispatcherTimer.Tick += timer_Tick;
            dispatcherTimer.IsEnabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            y = y + 0.1;
            collectPoint.point = new Point(x, Math.Sin(y)*100+100);
            collectPoint.curTime = DateTime.Now;
            userControl.AddPoint1(collectPoint);
        }

        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.IsEnabled = false;//关闭中断
        }
    }
}
