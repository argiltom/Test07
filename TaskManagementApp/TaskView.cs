using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            UpdateDataGrid();
        }
        public void UpdateDataGrid()
        {
            ObservableCollection<Task> oc = new ObservableCollection<Task>();
            foreach(Task task in AccessorTaskList.taskList)
            {
                oc.Add(task);
            }
            dataGrid.ItemsSource = oc;
 
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
