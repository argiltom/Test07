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
    /// C2_TaskViewUnit.xaml の相互作用ロジック
    /// </summary>
    public partial class C2_TaskViewUnit : UserControl
    {
        /// <summary>
        /// xamlのsummaryTextと連携(依存関係プロパティ)
        /// </summary>
        public Task task;
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
        public string SummaryText {
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



        public C2_TaskViewUnit(Task task)
        {
            InitializeComponent();
            SummaryText = task.taskSummary;
            TaskLimitText ="期限："+task.taskLimit;
            TaskImportanceText = "重要度:" +task.taskPriority;
            this.task = task;
        }

        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            C5_TaskEdit te = new C5_TaskEdit(task);
            te.Show();
        }
    }
}
