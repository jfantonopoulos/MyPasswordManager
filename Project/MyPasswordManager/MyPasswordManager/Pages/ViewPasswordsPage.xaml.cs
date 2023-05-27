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
    /// Interaction logic for ViewPasswordsPage.xaml
    /// </summary>
    public partial class ViewPasswordsPage : Page
    {
        public ViewPasswordsPage()
        {
            InitializeComponent();
        }

        private void CredStackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            SQLiteInterface sqliteInterface = Singleton<SQLiteInterface>.GetInstance();
            string sql = sqliteInterface.GetPresetQuery("SelectCredentials");
            var results = sqliteInterface.ExecuteQuery(sql, CommandType.Text);

            foreach (var result in results)
            {
                CredentialItem credItem = new CredentialItem(int.Parse(result.GetValues(0)[0]), result.GetValues(1)[0].ToString(), result.GetValues(2)[0].ToString(), result.GetValues(3)[0].ToString());
                credStackPanel.Children.Add(credItem);
            }
        }
    }
}

