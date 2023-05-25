using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace mi.net2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        autorisation auth = new autorisation();
        DataBase data = new DataBase();
        SqlCommand command = new SqlCommand();
        public MainWindow()
        {
            InitializeComponent();
            // Создание экземпляра класса PrintDocument
            PrintDocument pd = new PrintDocument();

            // Обработчик события печати страницы
            pd.PrintPage += new PrintPageEventHandler(PrintPageHandler);

            // Установка принтера по умолчанию
            pd.PrinterSettings.PrinterName = PrinterSettings.InstalledPrinters[0];

            // Установка настроек печати
            Margins margins = new Margins(100, 100, 100, 100); // Отступы в пикселях
            pd.DefaultPageSettings.Margins = margins;

            // Запуск печати
            pd.Print();
        }

        // Обработчик события печати страницы
        private static void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // Создание объекта Graphics из текущего события печати
            Graphics g = e.Graphics;

            // Создание объекта Font для текста
            Font font = new Font("TimesNewRoman", 12);

            // Создание объекта Brush для цвета текста
            System.Drawing.Brush brush = System.Drawing.Brushes.Black;

            // Получение размеров страницы
            float pageWidth = e.PageBounds.Width;
            float pageHeight = e.PageBounds.Height;

            // Определение позиции для печати текста
            float x = 100; // Горизонтальное смещение
            float y = 100; // Вертикальное смещение

            // Получение ссылки на элемент управления DataGrid
            DataGrid dataGrid = GetYourDataGridReference(); // Замените на ссылку на свой элемент DataGrid

            // Печать заголовков столбцов
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                g.DrawString(dataGrid.Columns[i].HeaderText, font, brush, x, y);
                x += dataGrid.Columns[i].Width;
            }

            // Печать содержимого ячеек
            y += 20; // Смещение после печати заголовков

            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                x = 100; // Возврат в начальную позицию по горизонтали

                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    g.DrawString(dataGrid.Rows[i].Cells[j].FormattedValue.ToString(), font, brush, x, y);
                    x += dataGrid.Columns[j].Width;
                }

                y += 20; // Смещение после печати строки
            }
        }

        private static DataGridView GetYourDataGridReference()
        {
            // Здесь вам нужно вернуть ссылку на ваш элемент управления DataGrid.
            // Если вы используете Windows Forms, у вас может быть ссылка на экземпляр класса DataGridView, например:
            // return dataGridView1;

            // Если вы используете WPF, у вас может быть ссылка на экземпляр класса DataGrid, например:
            // return dataGrid1;

            // Замените этот код на свою реализацию.
            return null;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            new autorisation().Show();
            this.Close();
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            autorisation auth = new autorisation();
            //RolesUser rl = new RolesUser();
            //{

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            //    string userRole = $"SELECT RoleId FROM UserData WHERE UserData.LoginUser = 'admin'";
            //    command = new SqlCommand(userRole, data.GetConnection());

            //    adapter.SelectCommand = command;
            //    adapter.Fill(dataTable);

            //    if (dataTable.Rows.Count > 0)
            //    {
            //        int userRoleId = (int)dataTable.Rows[0]["RoleId"];

            //        // Проверка роли и предоставление доступа к окну администратора
            //        if (userRoleId == 1) // Пример: 1 - роль администратора
            //        {
            //            // Открыть окно администратора
            //            Adminpanel adminPanelWindow = new Adminpanel();
            //            adminPanelWindow.Show();
            //        }
            //        else
            //        {
            //            // Пользователь не является администратором, выполните действия для других ролей или показывайте сообщение об ошибке
            //            MessageBox.Show("У вас нет доступа к административной панели.");
            //        }
            //    }
            //    else
            //    {
            //        // Пользователь не найден, выполните действия в случае отсутствия пользователя или показывайте сообщение об ошибке
            //        MessageBox.Show("Пользователь не найден.");
            //    }

            //}
            // Получите имя текущего пользователя


            // Запрос для получения роли пользователя
            string query = "SELECT R.RoleName FROM UserData U INNER JOIN RolesUser R ON U.RoleId = R.RoleId WHERE U.LoginUser = @Username";

            using (SqlCommand command = new SqlCommand(query, data.GetConnection()))
            {

                adapter.SelectCommand = command;
                adapter.Fill(dataTable);
                command.Parameters.AddWithValue("@Username", currentUser);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string userRole = reader["RoleName"].ToString();

                        if (userRole == "admin")
                        {
                            // Открываем окно admin panel
                            Adminpanel adminPanelWindow = new Adminpanel();
                            adminPanelWindow.Show();
                        }
                        else
                        {
                            // У пользователя нет прав доступа к административной панели
                            MessageBox.Show("У вас нет прав доступа к административной панели.");
                        }
                    }
                    else
                    {
                        // Пользователь не найден или у него нет роли
                        MessageBox.Show("Пользователь не найден или у него нет роли.");
                    }
                }
            }
        }

    

        private void helpme_Click(object sender, RoutedEventArgs e)
        {
            new helpme().Show();
        }

        private void graph_Click(object sender, RoutedEventArgs e)
        {
            new graph().Show();
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
