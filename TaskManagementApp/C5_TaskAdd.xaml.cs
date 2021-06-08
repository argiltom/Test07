using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskManagementApp
{
    /// <summary>
    /// TaskAdd.xaml の相互作用ロジック
    /// </summary>
    public partial class C5_TaskAdd : Window
    {
        string summary = "";
        string info = "";
        string priority = "0";
        DateTime deadline = DateTime.Now;
        public C5_TaskAdd()
        {
            InitializeComponent();
            this.DataContext = new C5_PriorityList();
            AccessorTaskList atl = new AccessorTaskList();
            atl.InitializeJsonData();
            AccessorOptionData aod = new AccessorOptionData();
            aod.InitializeJsonData();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.summary = taskSummary.Text;
        }
        private void TextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.info = taskInfo.Text;
        }

        private void combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.priority = taskPriority.SelectedValue.ToString();
        }

        private void taskDeadline_ValueChanged(object sender, SelectionChangedEventArgs e)
        {
            this.deadline = taskDeadline.SelectedDate.Value;
        }

        private void Add_Click(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
