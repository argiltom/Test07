using System.Collections.Generic;
using System.Diagnostics;


namespace TaskManagementApp
{
    public class C5_TaskFileProcess
    {
        AccessorTaskList atl;
        public C5_TaskFileProcess()
        {
            atl = new AccessorTaskList();
        }
        public void TaskSend(string summary, string info, int priority, string limit)
        {
            atl.AddTaskList(new Task() { taskID = 2, taskInfo = info, taskSummary = summary, taskPriority = priority, taskLimit = limit });
        }
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
            preTask.taskInfo = info;
            preTask.taskSummary = summary;
            preTask.taskPriority = priority;
            preTask.taskLimit = limit;
            preTask.taskNoticeComplishedBefore3Day = false;
            preTask.taskNoticeComplishedBefore1Day = false;
            Debug.WriteLine("OK?");
            Debug.WriteLine(preTask.taskInfo);
            Debug.WriteLine(preTask.taskSummary);
            Debug.WriteLine(preTask.taskPriority);
            Debug.WriteLine(preTask.taskLimit);

        }
    }
}
