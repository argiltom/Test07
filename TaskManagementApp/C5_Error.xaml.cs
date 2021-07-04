//********************
//Designer:渡邊淳平
//Date:2021/07/03
//Purpose:エラー画面
//********************


using System.Windows;

namespace TaskManagementApp
{
    /// <summary>
    /// C5_Error.xaml の相互作用ロジック
    /// </summary>

    //***********************************
    //Class Name:C5_TaskEdit
    //Designer:渡邊淳平
    //Date:2021/07/03
    //Function:エラー画面の表示
    //************************************

    public partial class C5_Error : Window
    {
        string eMess = "エラー";//エラーメッセージ初期化
        public C5_Error(bool isSummary)//コンストラクタ
        {
            InitializeComponent();//ウィンドウ初期化
            if (isSummary)//概要の文字数が不正か
            {
                eMess = "概要は１文字以上150字未満にしてください。";//概要の文字数が不正
            }
            else
            {
                eMess = "詳細は１文字以上10000字未満にしてください。";//詳細の文字数が不正
            }
            C5_Errormessage em = new C5_Errormessage();//バインディングの準備
            em.message = eMess;//エラーメッセージを入れる
            this.DataContext = em;//エラーメッセージをウィンドウに反映
        }

        //***********************************
        //Method Name:Back
        //Designer:渡邊淳平
        //Date:2021/07/03
        //Function:ボタンを押すとメイン画面に戻る
        //************************************

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();//このウィンドウを閉じる
        }
    }
}
