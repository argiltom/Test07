using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    public class C5_TaskFileProcess
    {
        AccessorTaskList atl;
        public C5_TaskFileProcess()
        {
            atl = new AccessorTaskList();
            atl.InitializeJsonData();

        }
        public void TaskSend(string summary, string info, int priority, string limit)
        {
            atl.AddTaskList(new Task() { taskID = 2, taskInfo = info, taskSummary = summary, taskPriority = priority, taskLimit = limit });
        }
    }
}
