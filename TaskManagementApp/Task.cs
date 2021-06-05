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
        public int taskID { set; get; }
        public string taskSummary { set; get; }
        public string taskInfo { set; get; }
        public string taskLimit { set; get; }
        public int taskPriority { set; get; }
    }
}
