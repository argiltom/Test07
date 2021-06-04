using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    /// <summary>
    /// M7:TaskClass
    /// </summary>
    [Serializable] public class Task
    {
        public int taskID;
        public string taskSummary;
        public string taskInfo;
        public DateTime taskLimit;
        public int taskPriority;
    }
}
