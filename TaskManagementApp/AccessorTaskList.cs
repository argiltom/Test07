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
        /// 情報を一時的にホールドしておく、最終的にはこいつに更新をドゥンドゥン加えていって、こいつをファイル入力情報にしてcsvを上書きする
        /// </summary>
        List<string[]> csvData;
        /// <summary>
        /// csvファイルから情報を読み取り,csvDataに上書きする
        /// </summary>
        public void InitializeCsvData()
        {
            //このプロジェクトのカレントディレクトリのパスを取得

                StreamReader sr = new StreamReader(@"E:\develop\kodo1B\TaskManagementApp\F1_TaskData\taskData.csv",Encoding.UTF8);
                List<string[]> fileData = new List<string[]>();
                while (!sr.EndOfStream)
                {
                    //csvから文字列を受け取って,分割して格納する
                    string line = sr.ReadLine();
                    fileData.Add(line.Split(','));
                }
                csvData = fileData;
                //試験コード
                foreach(string[] str in csvData){
                    foreach(string str2 in str)
                    {
                        Console.Write(str2);
                    }
                Console.Write("\n");
            }
                sr.Close();
            
            
        }
        public List<Task> getTaskList()
        {
            List<Task> taskList = new List<Task>();
            
            return taskList;
        }
    }
}
