//********************
//Designer:鈴木智仁
//Date:2021/06/25
//Purpose:タスクの消去についてユーザに質問する処理
//********************

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
    /// C2_TaskCompleateAskWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class C2_TaskCompleateAskWindow : Window
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
