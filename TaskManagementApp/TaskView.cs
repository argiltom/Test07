using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

/// <summary>
/// 試験用スクリプト 
/// </summary>
namespace TaskManagementApp
{
    /// <summary>
    /// このクラスはそろそろお蔵入り
    /// <para>C3:ホーム画面表示</para>
    /// <para>M2-1　タスクリスト表示</para>
    /// </summary>
    public class TaskView
    {
        DataGrid dataGrid;
        /// <summary>
        /// コンストラクタにはDataGrid型を渡す 
        /// </summary>
        /// <param name="getDataGrid"></param>
        public TaskView(DataGrid getDataGrid)
        {
            dataGrid = getDataGrid;
            UpdateDataGrid(AccessorTaskList.taskList);
        }
        /// <summary>
        /// オーバロード
        /// </summary>
        /// <param name="getDataGrid"></param>
        /// <param name="tasks"></param>
        public TaskView(DataGrid getDataGrid, List<Task> tasks)
        {
            dataGrid = getDataGrid;
            UpdateDataGrid(tasks);
        }


        public void UpdateDataGrid(List<Task> tasks)
        {
            ObservableCollection<Task> oc = new ObservableCollection<Task>();
            foreach (Task task in tasks)
            {
                oc.Add(task);
            }
            dataGrid.ItemsSource = oc;

        }
    }
    /*
     DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler();
     */
}
