﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        DispatcherTimer dispatcherTimer;
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
            dispatcherTimer = new DispatcherTimer();

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(200);
            dispatcherTimer.Tick += new EventHandler(MainWindowUpdate);
            dispatcherTimer.Start();
        }

        private void addTaskButton_Click(object sender, RoutedEventArgs e)
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
            Notice notice = new Notice();

            //notice.NoticeON();


            TaskViewStackPanelController.UpdateTaskViewStakPanel(SPtaskView, Sort.MainSort(AccessorTaskList.taskList));
            //作りたいものが先にあって、それを実現する方法を調べて、実装する．
            //作りたいのか、リファレンスを理解したいのか、目的は統一した方が良い
            //作りたいのなら、リファレンスへの理解は二の次でよい　
            //作りたいのなら、他の人が作ったものをそのまま部品として組み込んでよい！
            //それが避けられる戦いならば沈黙を貫き
            //それが必要な戦いならば、最後まで戦い抜く
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Console.WriteLine("終了処理!!!");
            dispatcherTimer.Stop();
            base.OnClosing(e);
        }
        private void editTaskButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }

}
