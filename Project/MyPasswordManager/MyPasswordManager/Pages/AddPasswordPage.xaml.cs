using Microsoft.Win32;
using MyPasswordManager.Classes;
using MyPasswordManager.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Security.Principal;
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

namespace MyPasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for AddPasswordPage.xaml
    /// </summary>
    public partial class AddPasswordPage : Page
    {
        public AddPasswordPage()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(CredTxtbox.Text))
                return false;
            if (string.IsNullOrEmpty(UserTxtbox.Text))
                return false;
            if (string.IsNullOrEmpty(PwdTxtbox.Password))
                return false;
            return true;
        }

        private void StoreBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckFields())
            {
                FeedbackWindow.Show("Cannot add credential!", "You must fill in all the fields.", Color.FromArgb(255, 255, 150, 150));
                return;
            }
            var sqlInterface = Singleton<SQLiteInterface>.GetInstance();
            var sql = sqlInterface.GetPresetQuery("AddCredentials");
            var pf = Singleton<ParamFactory>.GetInstance();
            string cipherText = Singleton<Crypto>.GetInstance().EncryptAES(PwdTxtbox.Password, Singleton<Config>.GetInstance().GetEncryptionKey());
            sqlInterface.ExecuteNonQuery(sql, CommandType.Text, new List<Tuple<string, dynamic>>{ pf.MakeParam("source", CredTxtbox.Text), pf.MakeParam("username", UserTxtbox.Text), pf.MakeParam("passhash", cipherText)});
            CredTxtbox.Clear();
            UserTxtbox.Clear();
            PwdTxtbox.Clear();
            FeedbackWindow.Show("Operation successful!", "You successfully added that credential!", Color.FromArgb(255, 150, 255, 150));
            Singleton<GlobalObjects>.GetInstance().ContentFrame.Navigate(new ViewPasswordsPage());
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Singleton<GlobalObjects>.GetInstance().ContentFrame.Navigate(new ViewPasswordsPage());
        } 
    }
}
