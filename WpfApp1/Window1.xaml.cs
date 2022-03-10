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
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window

    {
        DataBase database = new DataBase();
        public MainWindow mainWindow;
        public Window1()
        {
            InitializeComponent();
            
        }
        private void login_click(object sender, RoutedEventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passwordUser = password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id, login, password from users where login = '{loginUser}' and password = '{passwordUser}'";
            SqlCommand command = new SqlCommand(querystring, database.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if ((textBox_login.Text.Equals("")) || (password.Text.Equals("")))
                MessageBox.Show("Заполните данные!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                
            if (table.Rows.Count == 1)
            {



                MessageBox.Show("Добро пожаловать!", "Вход", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                MainWindow mainWindow = new MainWindow();
                this.Hide();
                mainWindow.ShowDialog();


            }
            else
                MessageBox.Show("Аккаунта не существует!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        }
        private void reg_click(object sender, RoutedEventArgs e)
        {
           Window2 window2 = new Window2();
            window2.Show();
            this.Hide();
        }


    }
}
