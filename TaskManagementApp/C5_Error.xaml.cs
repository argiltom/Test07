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
    /// C5_Error.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_Error : Window
    {
        string errorMassege = "エラー";
        public C5_Error(bool isSummary)
        {
            InitializeComponent();
            if (isSummary)
            {
                errorMassege = "概要は150字までにしてください。";
            }
            else
            {
                errorMassege = "詳細は10000字までにしてください。";
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
