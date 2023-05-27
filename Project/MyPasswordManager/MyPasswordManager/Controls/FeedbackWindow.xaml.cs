using MyPasswordManager.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace MyPasswordManager.Controls
{
    /// <summary>
    /// Interaction logic for FeedbackWindow.xaml
    /// </summary>
    /// 
    public partial class FeedbackWindow : Window
    {
        public SolidColorBrush TitleBarColor { get; set; } = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        public int TitleBarBorderRadius { get; set; } = 16;
        public string TitleBarBorderThickness { get; set; } = "5, 30, 5, 5";
        public string TitleBarLabelMargin { get; set; } = "4, -5, 10, 0";
        public SolidColorBrush TitleBarTextColor { get; set; } = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        
        public FeedbackWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public FeedbackWindow(string title, string msg)
        {
            InitializeComponent();
            DataContext = this;
            this.Title = title;
            this.FeedbackTxtBx.Text = msg;
            /*var margArray = TitleBarLabelMargin.Replace(" ", "").Split(',');
            var newMargin = "";
            var cnt = 0;
            foreach(var marg in margArray)
            {
                var intMarg = int.Parse(marg);
                if (cnt == 0) // left
                    newMargin = (intMarg + TitleBarBorderRadius).ToString();
                else if (cnt < margArray.Length)
                {
                    newMargin += $", {marg}";
                }
                cnt++;
            }
            TitleBarLabelMargin = newMargin;*/

        }
            public static bool? Show(string title, string msg, Color color)
            {
                FeedbackWindow newWindow = new FeedbackWindow(title, msg);
                newWindow.TitleBarColor = new SolidColorBrush(color);
                Singleton<GlobalObjects>.GetInstance().MainFeedbackWindow = newWindow;
                return newWindow.ShowDialog();
            }

        private void FeedbackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.HideCloseButton();
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
            this.Focus();
        }
    }
}
