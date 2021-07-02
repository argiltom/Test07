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

//追加import 追記者 鈴木智仁
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace TaskManagementApp
{
    /// <summary>
    /// TaskAdd.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_TaskAdd : Window
    {
        //7/2 例外排除の為,×ボタンの無効化 追記者 鈴木智仁

        //externは「これが外部で実装されている」を意味する
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

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
            cancel.ShowDialog();
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
                error.ShowDialog();
            }
            if (this.info.Length >= 10000)
            {
                C5_Error error = new C5_Error(false);
                error.ShowDialog();
            }
            if (this.info.Length < 10000 && this.summary.Length < 150)
            {
                tfp.TaskSend(this.summary, this.info, this.priority + 1, this.limit.ToString());
                Close();
            }

        }
    }
}
