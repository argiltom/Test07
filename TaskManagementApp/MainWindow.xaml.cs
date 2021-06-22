using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

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
            
            Console.WriteLine(nowTime.ToString());
            nowTimeView.Text = nowTime.ToString();
            AccessorTaskList atl = new AccessorTaskList();
            atl.InitializeJsonData();
            AccessorOptionData aod = new AccessorOptionData();
            aod.InitializeJsonData();
            //TaskView taskview = new TaskView(taskViewGrid);
            Console.WriteLine("mainWindow稼働中");
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(MainWindowUpdate);
            dispatcherTimer.Start();
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            C5_TaskAdd ta = new C5_TaskAdd();
            ta.Show();
            
        }
        /// <summary>
        /// C2 MainWindowでタスク表示を常時更新させる処理
        /// </summary>
        private void MainWindowUpdate(object sender,EventArgs eventArgs)
        {
            nowTime= DateTime.Now;
            nowTimeView.Text = nowTime.ToString();
            
            TaskViewStackPanelController.UpdateTaskViewStakPanel(SPtaskView, Sort.SortImportance(AccessorTaskList.taskList));
             //Console.WriteLine("アタランテ");
            
        }
    }

}
