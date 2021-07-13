using System;
using System.Collections.Generic;
using System.Linq;
//********************
//Designer:武藤渉
//Date:2021/06/15
//Purpose:タスクリストのソート処理の記述
//********************
namespace TaskManagementApp
{
    /// <summary>
    /// C4  Sort
    /// </summary>
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
        ///   バブルソート利用
        /// </summary>
        public static List<Task> SortLimit(List<Task> tasks)
        {

            for (int i = 0; i < tasks.Count() - 1; i++)
            {
                for (int k = 0; k < tasks.Count() - i - 1; k++)
                {
                    DateTime time = DateTime.Parse(tasks[k].taskLimit);
                    DateTime nextTime = DateTime.Parse(tasks[k + 1].taskLimit);
                    //nextTime の方がより過去の時刻の場合
                    if (time > nextTime)
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
        ///   バブルソート利用
        /// </summary>
        public static List<Task> SortImportance(List<Task> tasks)
        {

            for (int i = 0; i < tasks.Count() - 1; i++)
            {
                for (int k = 0; k < tasks.Count() - i - 1; k++)
                {
                    int importance = tasks[k].taskPriority;
                    int nextImportance = tasks[k + 1].taskPriority;
                    //nextImportance の方がより重要度が低い場合 //6_12 鈴木智仁 一部コード修正
                    if (importance < nextImportance)
                    {
                        Task temp = tasks[k];
                        tasks[k] = tasks[k + 1];
                        tasks[k + 1] = temp;
                    }
                }
            }
            return tasks;
        }
    }
}
