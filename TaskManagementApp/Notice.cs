using Microsoft.Toolkit.Uwp.Notifications;/////////////
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


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
                comparedt1dt2 = (dt2.Date - dt1.Date).TotalDays;//差
                TaskColor(temp);//タスクの色変更更新
                if (noticeSwitch)
                {
                    
                    if (comparedt1dt2 > 1 && comparedt1dt2 <= 3)//期限1<day<=3日前の時　
                    {
                        if (!temp.taskNoticeComplishedBefore3Day) //期限3日前の通知が完了していないのなら
                        {
                            NoticePopUp(temp); //通知を行う
                            temp.taskNoticeComplishedBefore3Day = true;
                        }
                    }
                    else if (comparedt1dt2 >= 0 && comparedt1dt2 <= 1)//期限0日<=dat<=1日前の時
                    {
                        if (!temp.taskNoticeComplishedBefore1Day) //期限3日前の通知が完了していないのなら
                        {
                            NoticePopUp(temp); //通知を行う
                            temp.taskNoticeComplishedBefore1Day = true;
                        }
                    }
                    else if (comparedt1dt2<0)
                    {
                        
                    }
                    else
                    {
                        //なにもしない
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
            int taskInfoLength = temp.taskInfo.Length;//StringのLengthプロパティを参照
            //200字以上なら 200字以内に抑え込む
            if (taskInfoLength >= 200)
            {
                taskInfoLength = 200;
            }
            new ToastContentBuilder()
                 .AddArgument("action", "viewConversation")
                 .AddArgument("conversationId", 9813)
                 .AddText("タスクの期限が迫っています(あと"+comparedt1dt2+"日)\n" + temp.taskSummary)//タスク名とか
                 .AddText(temp.taskLimit)//期限など通知するタスクの情報を書く
                 //.AddText(temp.taskInfo)
                 .AddText(temp.taskInfo.Substring(0,taskInfoLength))
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
            if(comparedt1dt2 > 3)
            {
                task.taskNoticeColor = "#0000";
            }
            if (comparedt1dt2 > 1 && comparedt1dt2 <= 3)
            {
                task.taskNoticeColor = new Color(255, 255, 0).ToString();//タスクの枠色を黄色に変更する
            }
            else if (comparedt1dt2 >= 0 && comparedt1dt2 <= 1)
            {
                task.taskNoticeColor = new Color(255, 0, 0).ToString();//タスクの枠色を赤色に変更する
            }
            else if (comparedt1dt2 <0)
            {
                task.taskNoticeColor = new Color(0, 0, 0).ToString();
            }
            else
            {
                //何もしない
            }
            AccessorTaskList view = new AccessorTaskList();
            view.ViewTaskListToCosole();//色を反映させたい
        }
    }
}