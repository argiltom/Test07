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
    /// C2_TaskCompleateAskWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class C2_TaskCompleateAskWindow : Window
    {
        Task task;
        public C2_TaskCompleateAskWindow(Task targetTask)
        {
            task = targetTask;
            InitializeComponent();
            taskSummary.Text = targetTask.taskSummary;
        }
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            AccessorTaskList atl = new AccessorTaskList();
            atl.RemoveTaskList(task);
            Close();
        }
        private void No_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
