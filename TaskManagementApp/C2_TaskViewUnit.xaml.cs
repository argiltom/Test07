using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace TaskManagementApp
{
    /// <summary>
    /// C2_TaskViewUnit.xaml の相互作用ロジック
    /// </summary>
    public partial class C2_TaskViewUnit : UserControl
    {
        /// <summary>
        /// コンストラクタから受け取ったものを格納するもの
        /// </summary>
        Task task;
        /// <summary>
        /// これがtrueになるとTimer内の処理で自分自身のdispatcherTimerを破棄させる．
        /// </summary>
        public bool isDispatcherTimerDestory = false;

        DispatcherTimer dispatcherTimer;

        /// <summary>
        /// xamlのsummaryTextと連携(依存関係プロパティ)
        /// </summary>
        public static readonly DependencyProperty SummaryTextProperty =
            DependencyProperty.Register(
                    "SummaryText",
                    typeof(string),
                    typeof(C2_TaskViewUnit),//このプロパティを所有する型=このクラス名
                    new PropertyMetadata("summary")//初期値
                );
        /// <summary>
        /// SummaryTextへのアクセサー
        /// </summary>
        public string SummaryText
        {
            get
            {
                return (string)GetValue(SummaryTextProperty);
            }
            set
            {
                SetValue(SummaryTextProperty, value);
            }
        }
        /// <summary>
        /// xamlのBtnTaskComplishedと連携(依存関係プロパティ)
        /// </summary>
        public static readonly DependencyProperty BtnTaskComplishedProperty =
            DependencyProperty.Register("BtnTaskComplished", typeof(ICommand), typeof(C2_TaskViewUnit), new PropertyMetadata(null));

        public ICommand BtnTaskComplished
        {
            get { return (ICommand)GetValue(BtnTaskComplishedProperty); }
            set { SetValue(BtnTaskComplishedProperty, value); }
        }

        /// <summary>
        /// xamlのTaskLimitTextと連携(依存関係プロパティ)
        /// </summary>
        public static readonly DependencyProperty TaskLimitTextProperty =
            DependencyProperty.Register(
                    "TaskLimitText",
                    typeof(string),
                    typeof(C2_TaskViewUnit),//このプロパティを所有する型=このクラス名
                    new PropertyMetadata("summary")//初期値
                );
        /// <summary>
        /// TaskLimitTextへのアクセサー
        /// </summary>
        public string TaskLimitText
        {
            get
            {
                return (string)GetValue(TaskLimitTextProperty);
            }
            set
            {
                SetValue(TaskLimitTextProperty, value);
            }
        }

        /// <summary>
        /// xamlのTaskImportanceTextと連携(依存関係プロパティ)
        /// </summary>
        public static readonly DependencyProperty TaskImportanceTextProperty =
            DependencyProperty.Register(
                    "TaskImportanceText",
                    typeof(string),
                    typeof(C2_TaskViewUnit),//このプロパティを所有する型=このクラス名
                    new PropertyMetadata("null")//初期値
                );
        /// <summary>
        /// TaskImportanceTextへのアクセサー
        /// </summary>
        public string TaskImportanceText
        {
            get
            {
                return (string)GetValue(TaskImportanceTextProperty);
            }
            set
            {
                SetValue(TaskImportanceTextProperty, value);
            }
        }

        /// <summary>
        /// xamlのTaskNoticeColorと連携(依存関係プロパティ)
        /// </summary>
        public static readonly DependencyProperty TaskNoticeColorProperty =
            DependencyProperty.Register(
                    "TaskNoticeColor",
                    typeof(string),
                    typeof(C2_TaskViewUnit),//このプロパティを所有する型=このクラス名
                    new PropertyMetadata("#0000")//初期値 #ARGB
                );
        /// <summary>
        /// TaskNoticeColorへのアクセサー
        /// </summary>
        public string TaskNoticeColor
        {
            get
            {
                return (string)GetValue(TaskNoticeColorProperty);
            }
            set
            {
                //nullなら透明のまま
                if (value != null) SetValue(TaskNoticeColorProperty, value);
            }
        }

        /// <summary>
        /// xamlのSelectedTaskInfoButtonBorderColorと連携(依存関係プロパティ)
        /// </summary>
        public static readonly DependencyProperty SelectedTaskInfoButtonBorderColorProperty =
            DependencyProperty.Register(
                    "SelectedTaskInfoButtonBorderColor",
                    typeof(string),
                    typeof(C2_TaskViewUnit),//このプロパティを所有する型=このクラス名
                    new PropertyMetadata("#0000")//初期値 #ARGB
                );
        /// <summary>
        /// SelectedTaskInfoButtonBorderColorへのアクセサー
        /// </summary>
        public string SelectedTaskInfoButtonBorderColor
        {
            get
            {
                return (string)GetValue(SelectedTaskInfoButtonBorderColorProperty);
            }
            set
            {
                //nullなら透明のまま
                if (value != null) SetValue(SelectedTaskInfoButtonBorderColorProperty, value);
            }
        }

        public void SelectTaskButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.selectingTask = task;
        }




        public void CompleatedTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AccessorTaskList atl = new AccessorTaskList();
            atl.RemoveTaskList(task);
        }

        public C2_TaskViewUnit(Task task)
        {
            InitializeComponent();
            this.task = task;
            SummaryText = task.taskSummary;
            TaskLimitText = "期限：" + task.taskLimit;
            TaskImportanceText = "重要度:" + task.taskPriority;
            TaskNoticeColor = task.taskNoticeColor;

            //タスクビューの更新をマルチスレッディングで更新
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TaskViewUpdate);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(200);
            dispatcherTimer.Start();

        }
        /// <summary>
        /// TaskView1個1個に対してのUpdate処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void TaskViewUpdate(object sender, EventArgs eventArgs)
        {
            //現在選択しているタスクが自分であるなら
            if (MainWindow.selectingTask != null && MainWindow.selectingTask == task)
            {
                SelectedTaskInfoButtonBorderColor = "#FF0000";
            }
            else
            {
                SelectedTaskInfoButtonBorderColor = "#000000";
            }
            if (TaskNoticeColor != task.taskNoticeColor)
            {
                TaskNoticeColor = task.taskNoticeColor;
            }
            //自分自身の自動破棄 
            if (isDispatcherTimerDestory)
            {
                dispatcherTimer.Stop();
            }
        }

    }
}
