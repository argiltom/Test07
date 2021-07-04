//********************
//Designer:渡邊淳平
//Date:2021/07/03
//Purpose:タスク内容送信・変更
//********************

using System.Collections.Generic;
using System.Diagnostics;


namespace TaskManagementApp
{
    //***********************************
    //Class Name:C5_TaskFileProcess
    //Designer:渡邊淳平
    //Date:2021/07/03
    //Function:タスクの追加の準備・タスクの内容を書き換え
    //************************************

    public class C5_TaskFileProcess
    {
        AccessorTaskList atl;//タスクリストの管理クラス
        public C5_TaskFileProcess()//コンストラクタ
        {
            atl = new AccessorTaskList();
        }

        //***********************************
        //Method Name:TaskSend
        //Designer:渡邊淳平
        //Date:2021/07/03
        //Function:追加内容をタスクリストの管理クラスの追加メソッドに送る
        //************************************

        public void TaskSend(string summary, string info, int priority, string limit)
        {
            atl.AddTaskList(new Task() { taskID = 2, taskInfo = info, taskSummary = summary, taskPriority = priority, taskLimit = limit });//追加メソッドに送信
        }

        //***********************************
        //Method Name:TaskChange
        //Designer:渡邊淳平
        //Date:2021/07/03
        //Function:タスクの内容を編集した物に書き換える
        //************************************

        public void TaskChange(Task preTask, string summary, string info, int priority, string limit)
        {
            /*
            List<Task> taskList = atl.GetTaskList();
            
            int taskNum = taskList.IndexOf(preTask);
            Task changedTask = new Task() { taskID = 2, taskInfo = info, taskSummary = summary, taskPriority = priority, taskLimit = limit };
            taskList[taskNum] = changedTask;
            taskList[taskNum].taskNoticeComplishedBefore3Day = false;
            taskList[taskNum].taskNoticeComplishedBefore1Day = false;
            */
            //修正者:鈴木智仁　これだと,taskのListが変動した時に,System.ArgumentOutOfRangeExceptionを投げるので,引数のTaskの参照に直接追加情報を代入させました．
            preTask.taskInfo = info;//詳細書き換え
            preTask.taskSummary = summary;//概要書き換え
            preTask.taskPriority = priority;//優先度書き換え
            preTask.taskLimit = limit;//期限日書き換え
            preTask.taskNoticeComplishedBefore3Day = false;//3日前の通知リセット
            preTask.taskNoticeComplishedBefore1Day = false;//1日前の通知リセット
            Debug.WriteLine("OK?");
            Debug.WriteLine(preTask.taskInfo);
            Debug.WriteLine(preTask.taskSummary);
            Debug.WriteLine(preTask.taskPriority);
            Debug.WriteLine(preTask.taskLimit);

        }
    }
}
