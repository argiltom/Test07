using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    /// <summary>
    /// M6 タスクリスト読み書き
    /// csvDataに読み取った情報をそのままホールドしておく
    /// </summary>
    public class AccessorTaskList
    {
        /// <summary>
        /// csvファイルから読み取った情報をホールドしておく、最終的にはこいつに更新をドゥンドゥン加えていって、こいつをファイル入力情報にしてcsvを上書きする
        /// </summary>
        List<string[]> csvData;
        /// <summary>
        /// csvファイルから情報を読み取り,csvDataに上書きする
        /// </summary>
        public void InitializeCsvData()
        {
            //このプロジェクトの実行exeカレントディレクトリのパスを取得
                string exePath = System.IO.Directory.GetCurrentDirectory();
                StreamReader sr = new StreamReader(exePath+@"\..\..\F1_TaskData\taskData.csv",Encoding.UTF8);
                List<string[]> fileData = new List<string[]>();
                while (!sr.EndOfStream)
                {
                    //csvから文字列を受け取って,分割して格納する
                    string line = sr.ReadLine();
                    fileData.Add(line.Split(','));
                }
                csvData = fileData;
                //試験コード
                TestCord();
                sr.Close();            
        }
        /// <summary>
        /// 取得したファイル情報から、タスクのリストを生成し渡す．
        /// </summary>
        /// <returns></returns>
        public List<Task> GetTaskList()
        {
            List<Task> taskList = new List<Task>();
            foreach(String[] taskdata in csvData)
            {
                Task tempTask = new Task();
                tempTask.taskID = int.Parse(taskdata[0]);
                tempTask.taskSummary = taskdata[1];
                tempTask.taskInfo = taskdata[2];
                tempTask.taskLimit = DateTime.Parse(taskdata[3]);
                tempTask.taskPriority = int.Parse(taskdata[4]);
                taskList.Add(tempTask);
            }
            return taskList;
        }

        public void AddTaskList(Task inputTask)
        {
            string[] inputData = new string[5];
            
        }


        public void TestCord()
        {
            foreach (string[] str in csvData)
            {
                foreach (string str2 in str)
                {
                    Console.Write(str2);
                }
                Console.Write("\n");
            }
        }
    }
}
