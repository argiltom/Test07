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
        int priority = 1;
        DateTime limit = DateTime.Now;
        C5_Cancel cancel;
        C5_TaskFileProcess tfp;
        public C5_TaskAdd()
        {
            InitializeComponent();
            this.DataContext = new C5_PriorityList();
            cancel = new C5_Cancel(this);
            tfp = new C5_TaskFileProcess();
            addPriority.SelectedIndex = this.priority;
        }


        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancel.Show();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            this.summary = addSummary.Text;
            this.info = addInfo.Text;
            this.priority = addPriority.SelectedIndex;
            this.limit = addLimit.SelectedDate.Value;
            Debug.WriteLine(this.limit);
            Debug.WriteLine(this.summary);
            Debug.WriteLine(this.priority);
            Debug.WriteLine(this.info);
            if(this.summary.Length >= 150)
            {
                C5_Error error = new C5_Error(true);
                error.Show();
            }
            if (this.info.Length >= 10000)
            {
                C5_Error error = new C5_Error(false);
                error.Show();
            }
            if (this.info.Length < 10000 && this.summary.Length < 150)
            {
                tfp.TaskSend(this.summary, this.info, this.priority + 1, this.limit.ToString());
                Close();
            }

        }
    }
}
