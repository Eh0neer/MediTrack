using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace mi.net2
{
    /// <summary>
    /// Логика взаимодействия для autorisation.xaml
    /// </summary>
    public partial class autorisation : Window
    {
        DataBase dataBase = new DataBase();
        SqlCommand command = new SqlCommand();
        public autorisation()
        {
            InitializeComponent();
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = AppData.db.UserData.FirstOrDefault(u => u.LoginUser == logins.Text && u.PassUser == password.Text);

            if (currentUser != null)
            {
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка входа");
            }

        }
    }
}
