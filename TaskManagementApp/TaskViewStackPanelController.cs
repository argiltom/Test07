using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TaskManagementApp
{
    /// <summary>
    /// <para>C3:ホーム画面表示</para>
    /// <para>M2-1　タスクリスト表示</para>
    /// C2_TaskのStackPanel制御を行うクラス 
    /// </summary>
    /// 
    public class TaskViewStackPanelController
    {
        /// <summary>
        /// stackPanelにアクセスし、内容を更新させる
        /// <para>第一引数にStackPanel 第二引数に表示したいTaskList</para>
        /// </summary>
        /// <param name="stackPanel"></param>
        /// <param name="viewTasks"></param>
        public static void UpdateTaskViewStakPanel(StackPanel stackPanel,List<Task> viewTasks)
        {
            stackPanel.Children.RemoveRange(0, stackPanel.Children.Count);
            foreach (Task task in AccessorTaskList.taskList)
            {
                stackPanel.Children.Add(new C2_TaskViewUnit(task));
            }
        }
    }
}
