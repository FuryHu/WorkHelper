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

namespace WorkHelper.Item.Report
{
    /// <summary>
    /// ReportSetting.xaml 的交互逻辑
    /// </summary>
    public partial class ReportSetting : UserControl
    {
        public ReportSetting()
        {
            InitializeComponent();
            // 项目路径
            PojPath.Text = Properties.Settings.Default.PojPath;
            // 提交人名
            GitName.Text = Properties.Settings.Default.Name;
            // 分隔符
            Separate.Text = Properties.Settings.Default.Separate;
            // 过滤条件
            Filter.Text = Properties.Settings.Default.Filter;
        }

        private void ReportSettingSave_Click(object sender, RoutedEventArgs e)
        {
            // 项目路径
            Properties.Settings.Default.PojPath = PojPath.Text;
            // 提交人名
            Properties.Settings.Default.Name = GitName.Text;
            // 分隔符
            Properties.Settings.Default.Separate = Separate.Text;
            // 过滤条件
            Properties.Settings.Default.Filter = Filter.Text;

            Properties.Settings.Default.Save();
            Window.GetWindow(this).Close(); 
        }
    }
}
