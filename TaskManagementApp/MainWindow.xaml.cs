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
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace TaskManagementApp
{
    
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///<para>外部変数:ID=3</para>
        ///<para>現在時刻を格納する</para>
        ///<para>利用範囲:システム全体</para>
        /// </summary>
        public DateTime nowTime=DateTime.Now;
        public MainWindow()
        {

            InitializeComponent();
            nowTimeView.Text = nowTime.ToString();
            Console.WriteLine(nowTime.ToString());
            AccessorTaskList atl = new AccessorTaskList();
            atl.InitializeJsonData();
            AccessorOptionData aod = new AccessorOptionData();
            aod.InitializeJsonData();
            //TaskView taskview = new TaskView(taskViewGrid);
            TaskViewStackPanelController.UpdateTaskViewStakPanel(SPtaskView, Sort.SortImportance(AccessorTaskList.taskList));
        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
        {
            C5_TaskAdd ta = new C5_TaskAdd();
            ta.Show();
        }

        private void editTaskButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
