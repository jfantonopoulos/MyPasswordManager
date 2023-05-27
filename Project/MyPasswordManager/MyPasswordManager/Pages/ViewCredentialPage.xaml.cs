using MyPasswordManager.Classes;
using MyPasswordManager.Controls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace MyPasswordManager.Pages
{
    /// <summary>
    /// Interaction logic for ViewCredentialPage.xaml
    /// </summary>
    public partial class ViewCredentialPage : Page
    {
        int ID;
        string Source;
        string Username;
        string PassHash;
        public ViewCredentialPage(int id, string source, string username, string passHash)
        {
            InitializeComponent();
            ID = id;
            Source = source;
            Username = username;
            PassHash = passHash;
            SourceTxtbox.Text = source;
            UserTxtbox.Text = Username;
            PwdTxtbox.Text = Singleton<Crypto>.GetInstance().DecryptAES(PassHash, Singleton<Config>.GetInstance().GetEncryptionKey());
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Singleton<GlobalObjects>.GetInstance().ContentFrame.Navigate(new ViewPasswordsPage());
        }

        private bool CheckFields()
        {
            if (string.IsNullOrEmpty(SourceTxtbox.Text))
                return false;
            if (string.IsNullOrEmpty(UserTxtbox.Text))
                return false;
            if (string.IsNullOrEmpty(PwdTxtbox.Text))
                return false;
            return true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            string newSource = SourceTxtbox.Text;
            string newUsername = UserTxtbox.Text;
            string newPassword = PwdTxtbox.Text;
            if (!CheckFields())
            {
                FeedbackWindow.Show("Cannot modify credential!", "You must fill in all the fields.", Color.FromArgb(255, 255, 150, 150));
                return;
            }
            newPassword = Singleton<Crypto>.GetInstance().EncryptAES(newPassword, Singleton<Config>.GetInstance().GetEncryptionKey());

            var sqlInterface = Singleton<SQLiteInterface>.GetInstance();
            var sql = sqlInterface.GetPresetQuery("UpdateCredential");
            var pf = Singleton<ParamFactory>.GetInstance();

            sqlInterface.ExecuteNonQuery(sql, CommandType.Text, new List<Tuple<string, dynamic>> { pf.MakeParam("source", newSource), pf.MakeParam("username", newUsername), pf.MakeParam("passhash", newPassword), pf.MakeParam("id", ID) });
            FeedbackWindow.Show("Operation successful!", "You successfully modified that credential!", Color.FromArgb(255, 150, 255, 150));
            Singleton<GlobalObjects>.GetInstance().ContentFrame.Navigate(new ViewPasswordsPage());
        }
    }
}
