//********************
//Designer:渡邊淳平
//Date:2021/07/03
//Purpose:キャンセル処理
//********************


using System.Windows;

namespace TaskManagementApp
{
    /// <summary>
    /// Cancel.xaml の相互作用ロジック
    /// </summary>

    //***********************************
    //Class Name:C5_Cancel
    //Designer:渡邊淳平
    //Date:2021/07/03
    //Function:キャンセル画面でのボタン処理
    //************************************

    public partial class C5_Cancel : Window
    {
        C5_TaskAdd ta;//追加画面
        C5_TaskEdit te;//編集画面
        public C5_Cancel(C5_TaskAdd ta)//追加画面があるときのコンストラクタ
        {
            InitializeComponent();//ウィンドウ初期化
            this.ta = ta;
        }
        public C5_Cancel(C5_TaskEdit te)//編集画面があるときのコンストラクタ（オーバーロード）
        {
            InitializeComponent();//ウィンドウ初期化
            this.te = te;
        }

        //***********************************
        //Method Name:Yes_Click
        //Designer:渡邊淳平
        //Date:2021/07/03
        //Function:「はい」が押されたとき、追加または編集画面を閉じる。
        //************************************

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (ta != null)//追加からの場合
            {
                ta.Close();//追加画面を閉じる

            }
            if (te != null)//編集からの場合
            {
                te.Close();//編集画面を閉じる
            }
            Close();//この画面を閉じる
        }

        //***********************************
        //Method Name:No_Click
        //Designer:渡邊淳平
        //Date:2021/07/03
        //Function:「いいえ」が押されたとき、このウィンドウを非表示にする。
        //************************************

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Hide();//このウィンドウを非表示にする。
        }
    }
}
