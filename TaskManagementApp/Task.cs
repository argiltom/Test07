using System;

namespace TaskManagementApp
{
    /// <summary>
    /// M7:TaskClass
    /// </summary>
    [Serializable]
    public class Task
    {
        public int taskID { set; get; }
        public string taskSummary { set; get; }
        public string taskInfo { set; get; }
        public string taskLimit { set; get; }
        public int taskPriority { set; get; }
        /// <summary>
        /// C7 タスクの色(ユーザー指定) (使わないかも)
        /// </summary>
        public string taskColor { set; get; }
        /// <summary>
        /// C7 タスクの通知色設定(C2Notice側で制御)
        /// </summary>
        public string taskNoticeColor { set; get; }
        /// <summary>
        /// C7 C3にて3日前のタスクの通知が完了したならtrue 未完了ならfalse (C3のタスク通知で用いる) C5の方にも出来れば追記したい
        /// タスク期限を修正したら,この変数をfalseに戻す！！！！　C5側の責任
        /// </summary>
        public bool taskNoticeComplishedBefore3Day { set; get; }
        /// <summary>
        /// C7 C3にて1日前のタスクの通知が完了したならtrue 未完了ならfalse (C3のタスク通知で用いる) C5の方にも出来れば追記したい
        /// タスク期限を修正したら,この変数をfalseに戻す！！！！ C5側の責任
        /// </summary>
        public bool taskNoticeComplishedBefore1Day { set; get; }
    }
}
