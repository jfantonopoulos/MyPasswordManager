using MyPasswordManager.Classes;
using MyPasswordManager.Pages;
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

namespace MyPasswordManager.Controls
{
    /// <summary>
    /// Interaction logic for CredentialItem.xaml
    /// </summary>
    public partial class CredentialItem : UserControl
    {
        public int Id;
        string Source;
        string Username;
        string PassHash;
        public CredentialItem(int id, string source, string username, string passHash)
        {
            InitializeComponent();
            this.Id = id;
            this.Source = source;
            this.Username = username;
            this.PassHash = passHash;
            SourceLbl.Content = Source;
            UserLbl.Content = Username;
        }

        private void ViewBtn_Click(object sender, RoutedEventArgs e)
        {
            Singleton<GlobalObjects>.GetInstance().ContentFrame.Navigate(new ViewCredentialPage(Id, Source, Username, PassHash));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var sqlInterface = Singleton<SQLiteInterface>.GetInstance();
            var sql = sqlInterface.GetPresetQuery("RemoveCredential");
            var pf = Singleton<ParamFactory>.GetInstance();
            sqlInterface.ExecuteNonQuery(sql, CommandType.Text, new List<Tuple<string, dynamic>> { pf.MakeParam("id", Id)});
            FeedbackWindow.Show("Operation successful!", $"Credentials for {Source} have been deleted.", Color.FromArgb(255, 150, 255, 150));
            Singleton<GlobalObjects>.GetInstance().ContentFrame.Navigate(new ViewPasswordsPage()); //Reload the page.
        }
    }
}
