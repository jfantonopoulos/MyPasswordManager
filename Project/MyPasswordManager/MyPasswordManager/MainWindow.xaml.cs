using MyPasswordManager.Classes;
using MyPasswordManager.Pages;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyPasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Singleton<GlobalObjects>.GetInstance().ContentFrame = ContentFrame;
            Singleton<SQLiteInterface>.GetInstance("Data Source=PwdDB.sqlite", ".SQL.Tables.", ".SQL.Queries.");
            ContentFrame.Navigate(new AddPasswordPage());
        }

        private void AddPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new AddPasswordPage());
        }

        private void ViewPasswordsBtn_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(new ViewPasswordsPage());
        }

        private void ContentFrame_ContentRendered(object sender, EventArgs e)
        {
            ContentFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void PasswordManagerWindow_Activated(object sender, EventArgs e)
        {
            var fdbkWindow = Singleton<GlobalObjects>.GetInstance().MainFeedbackWindow;
            if (fdbkWindow != null)
            {
                fdbkWindow.WindowState = WindowState.Normal;
                fdbkWindow.Activate();
                fdbkWindow.Focus();
            }
        }
    }
}
