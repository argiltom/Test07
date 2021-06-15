using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        string summary = "";
        string info = "";
        string priority = "0";
        DateTime limit = DateTime.Now;
        C5_Cancel cancel;
        C5_TaskFileProcess tfp;
        public C5_TaskAdd()
        {
            InitializeComponent();
            this.DataContext = new C5_PriorityList();
            cancel = new C5_Cancel(this);
            tfp = new C5_TaskFileProcess();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.summary = addSummary.Text;
            Debug.WriteLine(addSummary.Text);
        }
        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.info = addInfo.Text;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.priority = addPriority.SelectedValue.ToString();
            Debug.WriteLine(this.priority);
        }

        private void taskDeadline_ValueChanged(object sender, SelectionChangedEventArgs e)
        {
            this.limit = addLimit.SelectedDate.Value;
            Debug.WriteLine(this.limit);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancel.Show();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            this.summary = addSummary.Text;
            this.info = addInfo.Text;
            this.limit = addLimit.SelectedDate.Value;
            Debug.WriteLine(this.limit);
            Debug.WriteLine(this.summary);
            Debug.WriteLine(this.info);
            tfp.TaskSend(this.summary, this.info, int.Parse(this.priority), this.limit.ToString());
            Close();
        }
    }
}
