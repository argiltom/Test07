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
        C5_TaskEdit te;
        public C5_Cancel(C5_TaskAdd ta)
        {
            InitializeComponent();
            this.ta = ta;
        }
        public C5_Cancel(C5_TaskEdit te)
        {
            InitializeComponent();
            this.te = te;
        }


        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (ta != null)
            {
                ta.Close();

            }
            if (te != null)
            {
                te.Close();
            }
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
