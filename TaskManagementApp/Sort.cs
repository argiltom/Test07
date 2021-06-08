using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
   public class Sort
    {
        /// <summary>
        /// オプションを参照に自動で切り替え
        /// </summary>
      public static List<Task> MainSort(List<Task> tasks)
        {
            Option option = AccessorOptionData.option;
            List<Task> sortResult = new List<Task>();
            if (option.sortOption == SortOption.limit)
            {
                sortResult = SortLimit(tasks);
            }
            else if (option.sortOption == SortOption.priority)
            {
                sortResult = SortImportance(tasks);
            }
            return sortResult;
        }
      /// <summary>
      ///   期限順に並び変える
      /// </summary>
      public static List<Task> SortLimit(List<Task> tasks)
        {

            for (int i=0; i<tasks.Count() -1; i++) 
            {
                for (int k=0; k<tasks.Count() -i -1; k++)
                {
                    DateTime time = DateTime.Parse(tasks[k].taskLimit);
                    DateTime nextTime = DateTime.Parse(tasks[k+1].taskLimit);
                    //nextTime の方がより過去の時刻の場合
                    if (time>nextTime)
                    {
                        Task temp = tasks[k];
                        tasks[k] = tasks[k + 1];
                        tasks[k + 1] = temp;
                    }   
                }
            }
            return tasks;
      }
      /// <summary>
      ///   重要度順に並び変える
      /// </summary>
      public static List<Task> SortImportance(List<Task> tasks)
      {
            return tasks;
      }
    }
}
