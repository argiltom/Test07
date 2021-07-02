using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskManagementApp
{
    /// <summary>
    /// <para>C2:ホーム画面表示</para>
    /// <para>M2-1　タスクリスト表示</para>
    /// C2_TaskのStackPanel制御を行うクラス 
    /// </summary>
    /// 
    public class TaskViewStackPanelController
    {
        static List<Task> viewTasks=new List<Task>();
        /// <summary>
        /// stackPanelにアクセスし、内容を更新させる
        /// <para>第一引数にStackPanel 第二引数に表示したいTaskList</para>
        /// </summary>
        /// <param name="stackPanel"></param>
        /// <param name="viewTasks"></param>
        public static void UpdateTaskViewStakPanel(StackPanel stackPanel,List<Task> inputViewTasks)
        {
            if (CompareTaskList(viewTasks, inputViewTasks))
            {
                //比較してクラスに格納されているタスクリストと引数のタスクリストの内容が変わっていないので、この処理は中断
                return;
            }
            else
            {
                //比較してクラスに格納されているタスクリストと引数のタスクリストの内容が変わっているので、処理を実行
                Console.WriteLine("stackPanelを更新");
                viewTasks = new List<Task>(inputViewTasks);
            }

            stackPanel.Children.RemoveRange(0, stackPanel.Children.Count);
            foreach (Task task in inputViewTasks)
            {
                stackPanel.Children.Add(new C2_TaskViewUnit(task));
            }
        }
        /// <summary>
        /// 二つのタスクリストを比較し、同じならtrue 違うならfalseを返す．
        /// </summary>
        /// <param name="tasksA"></param>
        /// <param name="tasksB"></param>
        /// <returns></returns>
        public static bool CompareTaskList(List<Task> tasksA, List<Task> tasksB)
        {
            
            if (tasksA.Count() != tasksB.Count())
            {
                return false;
            }
            for(int i = 0; i < tasksA.Count(); i++)
            {
                if (!tasksA[i].Equals(tasksB[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
