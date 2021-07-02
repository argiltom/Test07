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
//追加import 追記者 鈴木智仁
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace TaskManagementApp
{
    /// <summary>
    /// TaskEdit.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_TaskEdit : Window
    {
        //7/2 例外排除の為,×ボタンの無効化 追記者 鈴木智仁

        //externは「これが外部で実装されている」を意味する
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex,int dwNewLong);

        const int GWL_STYLE = -16;
        const int WS_SYSMENU = 0x80000;

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            int style = GetWindowLong(handle, GWL_STYLE);
            style = style & (~WS_SYSMENU);
            SetWindowLong(handle, GWL_STYLE, style);
        }

        //*/7/2 例外排除の為,×ボタンの無効化 追記者 鈴木智仁


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
            this.summary = editTask.taskSummary;//nullチェックを行ってくれ
            this.info = editTask.taskInfo;
            this.priority = editTask.taskPriority;
            this.limit = DateTime.Parse(editTask.taskLimit);
            editSummary.Text = this.summary;
            editInfo.Text = this.info;
            editPriority.SelectedItem = this.priority.ToString();
            editLimit.SelectedDate = this.limit;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancel.ShowDialog();
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            this.summary = editSummary.Text;
            this.info = editInfo.Text;
            this.priority = editPriority.SelectedIndex;
            this.limit = editLimit.SelectedDate.Value;
            if (this.summary.Length >= 150)
            {
                C5_Error error = new C5_Error(true);
                error.ShowDialog();
            }
            if (this.info.Length >= 10000)
            {
                C5_Error error = new C5_Error(false);
                error.ShowDialog();
            }
            if(this.summary.Length < 150 && this.info.Length < 10000)
            {
                tfp.TaskChange(this.preTask, this.summary, this.info, this.priority + 1, this.limit.ToString());

            }
            Close();
        }
    }
}
