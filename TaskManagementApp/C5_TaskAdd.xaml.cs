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
    /// TaskAdd.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_TaskAdd : Window
    {
        public C5_TaskAdd()
        {
            InitializeComponent();
            this.DataContext = new C5_PriorityList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
