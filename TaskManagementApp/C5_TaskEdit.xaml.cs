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
    /// TaskEdit.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_TaskEdit : Window
    {
        string summary;
        string info;
        string priority;
        DateTime limit;
        C5_Cancel cancel;
        C5_TaskFileProcess tfp;
        public C5_TaskEdit(string summary, string info, string priority, DateTime limit)
        {
            InitializeComponent();
            this.DataContext = new C5_PriorityList();
            AccessorTaskList atl = new AccessorTaskList();
            atl.InitializeJsonData();
            AccessorOptionData aod = new AccessorOptionData();
            aod.InitializeJsonData();
            cancel = new C5_Cancel(this);
            tfp = new C5_TaskFileProcess();
            this.summary = summary;
            this.info = info;
            this.priority = priority;
            this.limit = limit;
            editSummary.Text = this.summary;
            editInfo.Text = this.info;
            editPriority.Text = this.priority;
            editLimit.SelectedDate = this.limit;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.summary = editSummary.Text;
        }
        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.info = editInfo.Text;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.priority = editPriority.SelectedValue.ToString();
        }

        private void taskDeadline_ValueChanged(object sender, SelectionChangedEventArgs e)
        {
            this.limit = editLimit.SelectedDate.Value;
        }

        private void editTask_Click(object sender, SelectionChangedEventArgs e)
        {
        }

        private void editCancel_Click(object sender, RoutedEventArgs e)
        {
            cancel.Show();
        }

        private void editTask_Click(object sender, RoutedEventArgs e)
        {
            this.summary = editSummary.Text;
            this.info = editInfo.Text;
            this.priority = editPriority.SelectedValue.ToString();
            this.limit = editLimit.SelectedDate.Value;
            tfp.TaskSend(this.summary, this.info, int.Parse(this.priority), this.limit.ToString());
            Close();
        }
    }
}
