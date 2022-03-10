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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        DataBase dataBase = new DataBase();
        public MainWindow mainWindow;
        public Window2()
        {
            InitializeComponent();

        }
        private void back_click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            this.Hide();
            window1.ShowDialog();
        }
            private void rege_click(object sender, RoutedEventArgs e)
        {
            

            var login = login2.Text;
            var password = password2.Text;
            string querystring = $"insert into users ( login, password ) values ('{login}' , '{password}')";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            dataBase.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан", "Готово");
                Window1 window1 = new Window1();
                this.Hide();
                window1.ShowDialog();

            }
            else
            {
                MessageBox.Show("Аккаунт не создан!");

            }
            dataBase.closeConnection();
        }
        private Boolean checkuser()
        {
            var loginUser = login2.Text;
            var passUser = password2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id,login,password from users where login ='{loginUser}' and password = '{passUser}'";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует");
                return true;
            }
            else
            {
                return false;
            }



        }
    }
}
