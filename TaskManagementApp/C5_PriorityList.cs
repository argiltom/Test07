using System.Collections.ObjectModel;

namespace TaskManagementApp
{
    public class C5_PriorityList
    {
        //タスク優先度の初期化
        public ObservableCollection<string> Data { get; }
        public C5_PriorityList()
        {
            Data = new ObservableCollection<string>();
            for (int i = 1; i <= 10; i++)
            {
                Data.Add(i.ToString());
            }
        }
    }
}
