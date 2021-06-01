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

namespace TaskManagementApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            Summary sum = new Summary();
            DateTime datetime = DateTime.Now;
            nowTimeView.Text = datetime.ToString();


        }
        /// <summary>
        /// サマリー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            debugPrinter.Text = "ああああ";
        }
    }

    public class Summary
    {
        /// <summary>
        /// これはフィールド！！
        /// </summary>
        public int field;
    }
}
