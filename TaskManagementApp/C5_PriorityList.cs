//********************
//Designer:渡邊淳平
//Date:2021/07/03
//Purpose:タスク優先度の初期化
//********************


using System.Collections.ObjectModel;

namespace TaskManagementApp
{

    //***********************************
    //Class Name:C5_PriorityList
    //Designer:渡邊淳平
    //Date:2021/07/03
    //Function:タスク優先度を決定する為のコンボボックスの内容初期化
    //************************************

    public class C5_PriorityList
    {
        //タスク優先度の初期化
        public ObservableCollection<string> Data { get; }//バインディングのためのリスト
        public C5_PriorityList()//コンストラクタ
        {
            Data = new ObservableCollection<string>();//リスト作成
            for (int i = 1; i <= 10; i++)
            {
                Data.Add(i.ToString());//要素追加(1~10)
            }
        }
    }
}
