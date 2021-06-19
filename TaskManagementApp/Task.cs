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
        /// <summary>
        /// C6 タスクの色(ユーザー指定) (使わないかも)
        /// </summary>
        public string taskColor { set; get; }
        /// <summary>
        /// C6 タスクの通知色設定(C2Notice側で制御)
        /// </summary>
        public string taskNoticeColor { set; get; }
    }
}
