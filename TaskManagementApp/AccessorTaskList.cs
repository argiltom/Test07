using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskManagementApp
{
    /// <summary>
    /// M6 タスクリスト読み書き
    /// csvDataに読み取った情報をそのままホールドしておく
    /// </summary>
    public class AccessorTaskList
    {
        /// <summary>
        /// 外部変数
        /// ID :1 
        /// タスクリスト
        /// </summary>
        public List<Task> taskList;
        public void InitializeJsonData()
        {
            //このプロジェクトの実行exeカレントディレクトリのパスを取得
            string exePath = System.IO.Directory.GetCurrentDirectory();
            string getJsonString =System.IO.File.ReadAllText(exePath+ @"\..\..\F1_TaskData\taskData.json");//@特殊な文字を文字としてそのまま適用する

            //JsonSerializerを使うためには、対象となるクラスのフィールドには、プロパティを設定していないといけない
            taskList = JsonSerializer.Deserialize<List<Task>>(getJsonString);//Jsonファイルからクラスリスト生成

            Task tempTask = new Task() { taskID = 1, taskSummary = "タスクのサマリー", taskInfo = "テストタスクの中身", taskLimit = DateTime.Now.ToString(), taskPriority = 21 };
            taskList.Add(tempTask);
            WriteJsonData();
        }

        public void WriteJsonData()
        {

            string outJsonString = JsonSerializer.Serialize<List<Task>>(taskList);//クラスからJsonStringを生成
            string exePath = System.IO.Directory.GetCurrentDirectory();
            System.IO.File.WriteAllText(exePath + @"\..\..\F1_TaskData\taskData.json",outJsonString);//@特殊な文字を文字としてそのまま適用する
        }
        /// <summary>
        /// 取得したファイル情報から、タスクのリストを生成し渡す．
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTaskList()
        {
            return taskList;
            
        }


    }
}
