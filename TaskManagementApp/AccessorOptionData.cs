using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace TaskManagementApp
{
    /// <summary>
    /// M6-1　オプション設定情報読み書き
    /// </summary>
    public class AccessorOptionData
    {
        /// <summary>
        /// 外部変数
        /// ID :2 
        /// option設定情報
        /// </summary>
        static public Option option;
        string filePath = System.IO.Directory.GetCurrentDirectory() + @"\..\..\F2_OptionData\optionData.json";//@特殊な文字を文字としてそのまま適用する
        public void InitializeJsonData()
        {
            //このプロジェクトの実行exeカレントディレクトリのパスを取得
            if (File.Exists(filePath))
            {
                string getJsonString = System.IO.File.ReadAllText(filePath);//jsonfileが存在するなら読み込む
                //JsonSerializerを使うためには、対象となるクラスのフィールドには、プロパティを設定していないといけない
                option = JsonSerializer.Deserialize<Option>(getJsonString);//Jsonファイルからクラスリスト生成
            }
            else //jsonファイルが存在しないなら
            {
                Option defaultOption = new Option() { sortOption = SortOption.limit, isNoticeActivated = true, noticeColor = new Color(255, 0, 0).ToString() };
                string tempJsonString = JsonSerializer.Serialize<Option>(defaultOption);
                System.IO.File.WriteAllText(filePath, tempJsonString);//新しくjsonファイルを生成
                InitializeJsonData();//再度読み直す　そういう意図での再帰呼び出し
            }
            WriteJsonData();
            ViewOptionToCosole();
        }

        public void WriteJsonData()
        {

            string outJsonString = JsonSerializer.Serialize<Option>(option);//クラスからJsonStringを生成
            System.IO.File.WriteAllText(filePath, outJsonString);//@特殊な文字を文字としてそのまま適用する
        }

        public void ViewOptionToCosole()
        {

            Console.WriteLine("isNoticeActivated:"+option.isNoticeActivated);
            Console.WriteLine("sortOption:" + option.sortOption);
            Console.WriteLine("noticeColor:" + option.noticeColor);
        }
    }
}
