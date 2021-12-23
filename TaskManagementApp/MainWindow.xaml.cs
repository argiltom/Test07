using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

//********************
//Designer:鈴木智仁
//Date:2021/06/13
//Purpose:メイン画面の表示処理
//********************

namespace TaskManagementApp
{

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// 担当者:鈴木智仁
    /// <para> DataContainerに入れること: </para>
    /// <para>  バインディングパス名        (型)   </para>
    /// <para>    SortDaedLineOnVisibility    (Visibility)   </para>
    /// <para>    SortDaedLineOffVisibility   (Visibility)   </para>
    /// <para>    SortImportanceOnVisibility  (Visibility)   </para>
    /// <para>    SortImportanceOffVisibility (Visibility)   </para>
    /// <para>    lumpOnVisibility            (Visibility)   </para>
    /// <para>    lumpOffVisibility           (Visibility)   </para>
    /// <para>    EditTaskButtonVisibility    (Visibility)</para>
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///<para>外部変数:ID=3</para>
        ///<para>現在時刻を格納する</para>
        ///<para>利用範囲:システム全体
        /// </summary>
        public DateTime nowTime = DateTime.Now;
        /// <summary>
        /// <para>現在C2で選択しているタスク これの詳細を表示する</para>
        /// <para>外部変数と同じアクセシビリティではあるが、外部変数として使うことは許可しない</para>
        /// <para>あくまでC2のみで使う</para>
        /// </summary>
        public static Task selectingTask;
        DispatcherTimer dispatcherTimer;
        AccessorOptionData aod;
        AccessorTaskList atl;
        AccessorComplishedTaskList actl;
        /// <summary>
        /// 検索結果のリストを格納する.　これが実際に表示されるタスクの内容を格納する先である
        /// </summary>
        List<Task> taskSerchResult;
        /// <summary>
        /// 常時タスクを篩に掛けるための文字列
        /// </summary>
        String searchingTaskKey = "";
        public MainWindow()
        {
            InitializeComponent();

            Console.WriteLine(nowTime.ToString());
            nowTimeView.Text = nowTime.ToString();
            atl = new AccessorTaskList();
            atl.InitializeJsonData();
            aod = new AccessorOptionData();
            aod.InitializeJsonData();
            actl = new AccessorComplishedTaskList();
            actl.InitializeJsonData();
            //taskSerchResultの初期化
            taskSerchResult = AccessorTaskList.taskList;
            //TaskView taskview = new TaskView(taskViewGrid);
            dispatcherTimer = new DispatcherTimer();

            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(200);
            dispatcherTimer.Tick += new EventHandler(MainWindowUpdate);
            dispatcherTimer.Start();
        }


        /// <summary>
        /// C2 MainWindowでタスク表示を常時更新させる処理
        /// </summary>
        private void MainWindowUpdate(object sender, EventArgs eventArgs)
        {
            nowTime = DateTime.Now;
            nowTimeView.Text = nowTime.ToString();
            Notice notice = new Notice();

            notice.NoticeON();
            //選択しているタスクの情報をtaskInfoViewTextBlockに反映させる
            if (MainWindow.selectingTask != null)
            {
                taskInfoViewTextBlock.Text = selectingTask.taskInfo;
                //選択しているタスク(staticフィールドに格納されているクラス) が元のtaskListに存在していないなら,staticに格納されている
                if (!AccessorTaskList.taskList.Contains(MainWindow.selectingTask))
                {
                    MainWindow.selectingTask = null;
                }
            }
            else //未選択なら
            {
                taskInfoViewTextBlock.Text = "タスクを選択して下さい";
            }

            //タスク検索ボタンが押された際の検索情報をsearchingTaskKeyに保持している
            //それを元に検索結果を常時更新
            taskSerchResult = SerchTaskList(searchingTaskKey, AccessorTaskList.taskList);

            TaskViewStackPanelController.UpdateTaskViewStakPanel(SPtaskView, Sort.MainSort(taskSerchResult));

            BindingDataUpdater();


        }//常時更新処理部


        /// <summary>
        /// Bindingされた情報をDataContextに格納して更新させる処理
        /// </summary>
        private void BindingDataUpdater()
        {
            BindingStruct bindingStruct = new BindingStruct();
            //通知ランプの点灯切り替え処理
            if (AccessorOptionData.option.isNoticeActivated)
            {
                //通知ランプのBinding名と同様の変数名でないといけない
                bindingStruct.lumpOnVisibility = Visibility.Visible;
                bindingStruct.lumpOffVisibility = Visibility.Collapsed;

            }
            else
            {

                bindingStruct.lumpOnVisibility = Visibility.Collapsed;
                bindingStruct.lumpOffVisibility = Visibility.Visible;

            }
            //期限順ソートボタンの点灯切り替え処理
            if (AccessorOptionData.option.sortOption == SortOption.limit)
            {

                //指定されたBinding名と同様の変数名でないといけない
                bindingStruct.SortDaedLineOnVisibility = Visibility.Visible;
                bindingStruct.SortDaedLineOffVisibility = Visibility.Collapsed;
                bindingStruct.SortImportanceOnVisibility = Visibility.Collapsed;
                bindingStruct.SortImportanceOffVisibility = Visibility.Visible;

            }
            else
            {
                bindingStruct.SortDaedLineOnVisibility = Visibility.Collapsed;
                bindingStruct.SortDaedLineOffVisibility = Visibility.Visible;
                bindingStruct.SortImportanceOnVisibility = Visibility.Visible;
                bindingStruct.SortImportanceOffVisibility = Visibility.Collapsed;
            }
            //タスク編集ボタンの表示切替処理
            if (MainWindow.selectingTask != null) { 
                bindingStruct.EditTaskButtonVisibility = Visibility.Visible;
            }
            else
            {
                bindingStruct.EditTaskButtonVisibility = Visibility.Collapsed;
            }
            //データを格納したものをDataContextに渡す．
            this.DataContext = bindingStruct;
        }
        /// <summary>
        /// MainWindowのXAMLに紐づく,Binding情報をこのクラスから渡す.
        /// 渡すフィールドは必ずプロパティ(アクセサー)を設定すること
        /// </summary>
        public class BindingStruct
        {
            public Visibility lumpOnVisibility { get; set; }
            public Visibility lumpOffVisibility { get; set; }
            public Visibility SortDaedLineOnVisibility { get; set; }
            public Visibility SortDaedLineOffVisibility { get; set; }
            public Visibility SortImportanceOnVisibility { get; set; }
            public Visibility SortImportanceOffVisibility { get; set; }
            public Visibility EditTaskButtonVisibility { get; set; }
        }


        /// <summary>
        /// タスク追加ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            C5_TaskAdd ta = new C5_TaskAdd();
  
            ta.ShowDialog();
        }
        private void EditTaskButton_Click(object sender, RoutedEventArgs e)
        {
            //6/29バグ修正:nullチェックの導入
            if (MainWindow.selectingTask != null)
            {

                C5_TaskEdit taskEdit = new C5_TaskEdit(MainWindow.selectingTask);
                //6/29バグ修正:複数の画面起動を許さないようにした．
                taskEdit.ShowDialog();
            }

        }
        private void SerchTaskButton_Click(object sender, RoutedEventArgs e)
        {
            //タスク常時検索キーを更新
            searchingTaskKey = serchTextBox.Text;
            Console.WriteLine("タスク検索中=" + serchTextBox.Text);
        }
        public List<Task> SerchTaskList(String serchWord, List<Task> inputTaskList)
        {
            List<Task> fullList = inputTaskList;
            //デフォルトの状態だと全てのリストが表示される．
            if (serchWord.Equals("タスクの検索")){
                return fullList;
            }

            List<Task> resultTaskList = new List<Task>();
            foreach (Task task in fullList)
            {
                //7/13 日付検索も対応させた
                if (task.taskSummary.Contains(serchWord)||task.taskLimit.Contains(serchWord))
                {
                    resultTaskList.Add(task);
                    Console.WriteLine(task.taskSummary);
                }
            }
            return resultTaskList;
        }
        private void SortImportanceTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AccessorOptionData.option.sortOption = SortOption.priority;
            new AccessorOptionData().WriteJsonData();
        }

        private void SortDaedLineTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AccessorOptionData.option.sortOption = SortOption.limit;
            new AccessorOptionData().WriteJsonData();
        }
        /// <summary>
        /// 通知ボタンを押したときの挙動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notificateButton_Click(object sender, RoutedEventArgs e)
        {
            if (AccessorOptionData.option.isNoticeActivated)
            {
                AccessorOptionData.option.isNoticeActivated = false;
            }
            else
            {
                AccessorOptionData.option.isNoticeActivated = true;
            }
        }
        /// <summary>
        /// 終了処理
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Console.WriteLine("終了処理!!!");
            dispatcherTimer.Stop();
            atl.WriteJsonData();
            aod.WriteJsonData();
            actl.WriteJsonData();
            //申し訳程度のガベージコレクション
            GC.Collect();
            base.OnClosing(e);
        }
    }

    //作りたいものが先にあって、それを実現する方法を調べて、実装する．
    //作りたいのか、リファレンスを理解したいのか、目的は統一した方が良い
    //作りたいのなら、リファレンスへの理解は二の次でよい　
    //作りたいのなら、他の人が作ったものをそのまま部品として組み込んでよい！
    //それが避けられる戦いならば沈黙を貫き
    //それが必要な戦いならば、最後まで戦い抜く
    //Console.WriteLine("mainWindow稼働中"+serchTextBox.Text+taskSerchResult.Count());
}
