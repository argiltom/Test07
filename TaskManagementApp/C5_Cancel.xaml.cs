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
using System.Windows.Shapes;

namespace TaskManagementApp
{
    /// <summary>
    /// Cancel.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_Cancel : Window
    {
        C5_TaskAdd ta;
        public C5_Cancel(C5_TaskAdd ta)
        {
            InitializeComponent();
            this.ta = ta;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Close();
            ta.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
