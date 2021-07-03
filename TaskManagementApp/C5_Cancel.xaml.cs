using System.Windows;

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
