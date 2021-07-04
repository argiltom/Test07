//********************
//Designer:渡邊淳平
//Date:2021/07/03
//Purpose:タスク追加
//********************

using System;
using System.Diagnostics;
//追加import 追記者 鈴木智仁
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace TaskManagementApp
{
    /// <summary>
    /// TaskAdd.xaml の相互作用ロジック
    /// </summary>

    //***********************************
    //Class Name:C5_TaskAdd
    //Designer:渡邊淳平
    //Date:2021/07/03
    //Function:追加画面の表示・ボタン操作
    //************************************

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



        string summary = "";//概要
        string info = "";//詳細
        int priority = 1;//優先度
        DateTime limit = DateTime.Now;//期限日
        C5_Cancel cancel;//キャンセル画面
        C5_TaskFileProcess tfp;//タスクをリストに格納
        public C5_TaskAdd()//コンストラクタ
        {
            InitializeComponent();//ウィンドウの初期化
            this.DataContext = new C5_PriorityList();//優先度のコンボボックスの内容（１～１０）
            cancel = new C5_Cancel(this);
            tfp = new C5_TaskFileProcess();
            addPriority.SelectedIndex = this.priority;//コンボボックスの初期化
        }


        //***********************************
        //Class Name:Cancel_Click
        //Designer:渡邊淳平
        //Date:2021/07/03
        //Function:キャンセルボタンが押されたとき、キャンセル画面を表示
        //************************************

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancel.ShowDialog();//キャンセル画面表示
        }


        //***********************************
        //Class Name:AddTask_Click
        //Designer:渡邊淳平
        //Date:2021/07/03
        //Function:追加ボタンが押されたとき、概要か詳細の文字数が条件を満たしていない場合エラー画面を表示。満たした場合タスク追加の準備をする。
        //************************************

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {

            this.summary = addSummary.Text;//概要のテキストボックスから
            this.info = addInfo.Text;//詳細のテキストボックスから
            this.priority = addPriority.SelectedIndex;//優先度のコンボボックスから
            this.limit = addLimit.SelectedDate.Value;//期限日のデイトピッカーから
            this.limit=this.limit.AddHours(23.999999);


            Debug.WriteLine(this.limit);
            Debug.WriteLine(this.summary);
            Debug.WriteLine(this.priority);
            Debug.WriteLine(this.info);
            if (this.summary.Length >= 150 || this.summary.Length <= 0)//概要が0文字以下150字以上の時
            {
                C5_Error error = new C5_Error(true);//概要のエラー画面表示
                error.ShowDialog();
            }
            if (this.info.Length >= 10000 || this.info.Length <= 0)//詳細が0文字以下150字以上の時
            {
                C5_Error error = new C5_Error(false);//詳細のエラー画面表示
                error.ShowDialog();
            }
            if (this.info.Length < 10000 && this.summary.Length < 150 && this.info.Length > 0 && this.summary.Length > 0)//条件を満たしている場合
            {
                tfp.TaskSend(this.summary, this.info, this.priority + 1, this.limit.ToString());//タスクリストへの追加準備
                Close();//追加画面を閉じる
            }

        }
    }
}
