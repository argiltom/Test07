using System.Windows;

namespace TaskManagementApp
{
    /// <summary>
    /// C5_Error.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_Error : Window
    {
        string eMess = "エラー";
        public C5_Error(bool isSummary)
        {
            InitializeComponent();
            if (isSummary)
            {
                eMess = "概要は１文字以上150字未満にしてください。";
            }
            else
            {
                eMess = "詳細は１文字以上10000字未満にしてください。";
            }
            C5_Errormessage em = new C5_Errormessage();
            em.message = eMess;
            this.DataContext = em;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
