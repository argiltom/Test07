﻿using Microsoft.Toolkit.Uwp.Notifications;/////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    /// <summary>
    /// C3 通知
    /// </summary>
    public class Notice
    {
        double comparedt1dt2;
        /// <summary>
        /// タスクの通知がONかつ条件に当てはまるタスクをNoticePopUpとTaskColorを呼び出す
        /// </summary>

        public void NoticeON()
        {//通知がONだったらM3-1(タスクのポップアップ通知)とM3-2(タスクの枠色変更)モジュールを呼ぶ
            String color = AccessorOptionData.option.noticeColor;//noticeのNoticeColor
            bool noticeSwitch = AccessorOptionData.option.isNoticeActivated;//スイッチONかどうか
            foreach (Task temp in AccessorTaskList.taskList)//
            {
                DateTime dt1 = DateTime.Now;//現在時刻
                DateTime dt2 = DateTime.Parse(temp.taskLimit);//タスクの締め切り時間
                if (noticeSwitch)
                {
                    comparedt1dt2 = (dt2.Date - dt1.Date).TotalDays;//差
                    if (comparedt1dt2 == 3 || comparedt1dt2 == -3)//期限3日前の時
                    {
                        NoticePopUp(temp);//これで通知させたいやつだけのタスクが渡せてるのかわからん
                        TaskColor(temp);//これで通知させたいやつだけのcolorが渡せてるのかわからん
                    }
                    else if (comparedt1dt2 == -1 || comparedt1dt2 == 1)//期限1日前の時
                    {
                        NoticePopUp(temp);//上と同じ
                        TaskColor(temp);//上と同じ
                    }
                    else
                    {//多分なにもしない
                    }
                }
            }
        }
        /// <summary>
        /// ポップアップ通知でタスクの通知を行う
        /// </summary>
        public void NoticePopUp(Task temp)//タスク通知M表示　　引数に通知するタスクの情報が必要かも
        {
            // Requires Microsoft.Toolkit.Uwp.Notifications NuGet package version 7.0 or greater
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddArgument("conversationId", 9813)
                .AddText(temp.taskInfo)//タスク名とか
                .AddText(temp.taskLimit)//期限など通知するタスクの情報を書く
                .AddText(temp.taskSummary)
                 // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 5, your TFM must be net5.0-windows10.0.17763.0 or greater
                .Show(toast =>//////有効期限を設定
                 {
                     toast.ExpirationTime = DateTime.Now.AddSeconds(10);
                 });
        }

        /// <summary>
        /// NoticeONで呼び出されたタスクの枠色を変更する
        /// </summary>
        public void TaskColor(Task task)//タスク枠色変更　　引数に通知するタスクのオプション情報が必要かも
        {
            
            //NoticeONのcomparedt1dt2がほしい
            if (comparedt1dt2 == 3 || comparedt1dt2 == -3)
            {
                task.taskNoticeColor= new Color(255, 255, 0).ToString();//タスクの枠色を黄色に変更する
            }
            else if (comparedt1dt2 == 1 || comparedt1dt2 == -1)
            {
                task.taskNoticeColor = new Color(255, 0, 0).ToString();//タスクの枠色を赤色に変更する
            }
            else
            {
                //多分何もしない
            }
            AccessorTaskList view = new AccessorTaskList();
            view.ViewTaskListToCosole();//色を反映させたい
        }
    }
}