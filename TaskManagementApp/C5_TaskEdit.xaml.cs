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
        int priority;
        DateTime limit;
        C5_Cancel cancel;
        C5_TaskFileProcess tfp;
        Task preTask;
        public C5_TaskEdit(Task editTask)
        {
            InitializeComponent();
            this.DataContext = new C5_PriorityList();
            cancel = new C5_Cancel(this);
            tfp = new C5_TaskFileProcess();
            this.preTask = editTask;
            this.summary = editTask.taskSummary;
            this.info = editTask.taskInfo;
            this.priority = editTask.taskPriority;
            this.limit = DateTime.Parse(editTask.taskLimit);
            editSummary.Text = this.summary;
            editInfo.Text = this.info;
            editPriority.Text = this.priority.ToString();
            editLimit.SelectedDate = this.limit;
        }

        private void editCancel_Click(object sender, RoutedEventArgs e)
        {
            cancel.Show();
        }

        private void editTask_Click(object sender, RoutedEventArgs e)
        {
            this.summary = editSummary.Text;
            this.info = editInfo.Text;
            this.priority = editPriority.SelectedIndex;
            this.limit = editLimit.SelectedDate.Value;
            tfp.TaskChange(this.preTask, this.summary, this.info, this.priority + 1, this.limit.ToString());
            Close();
        }
    }
}
