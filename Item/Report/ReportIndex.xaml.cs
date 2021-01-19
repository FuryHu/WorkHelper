using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// ReportIndex.xaml 的交互逻辑
    /// </summary>
    public partial class ReportIndex : UserControl
    {
        private Window setting = null;

        public ReportIndex()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            // 项目路径
            string pojPath = Properties.Settings.Default.PojPath;
            // 提交人名
            string name = Properties.Settings.Default.Name;
            // 分隔符
            string pont = Properties.Settings.Default.Separate;
            // 过滤条件
            Regex regex = new Regex(Properties.Settings.Default.Filter);

            Repository rep = new Repository(pojPath);
            string weekly = "本周工作内容：";
            int index = 1;
            DateTimeOffset today = Convert.ToDateTime(DateTimeOffset.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            DateTimeOffset monday = today.AddDays(1 - Convert.ToInt32(today.DayOfWeek.ToString("d")));

            foreach (var branche in rep.Branches)
            {
                // 不是远程且是追踪的
                if (!branche.IsRemote && branche.IsTracking)
                {

                    foreach (var commit in branche.Commits)
                    {
                        if (commit.Author.Name == name && commit.Author.When >= monday && regex.IsMatch(commit.MessageShort))
                        {
                            weekly += "\r\n" + index++ + pont + commit.MessageShort;
                        }
                    }
                }
            }

            ReportText.Text = weekly;
        }

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            setting = new Window();
            setting.Title = "配置项目";
            setting.Content = new ReportSetting();
            setting.Width = 520;
            setting.Height = 400;
            new System.Windows.Interop.WindowInteropHelper(setting);
            setting.ShowDialog();
        }
    }
}
