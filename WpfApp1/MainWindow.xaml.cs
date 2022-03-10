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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {

        DataBase dataBase = new DataBase();
        public MainWindow mainWindow;
        public MainWindow()
        {
            InitializeComponent();


        }
        private void bron_click(object sender, RoutedEventArgs e)
        {


            var start_date = start_date2.Text;
            var finish_date = finish_date2.Text;    
            var type = type2.Text;
            var login = login2.Text;
            string querystring = $"insert into bron ( start_date, finish_date, type, login) values ('{start_date}' , '{finish_date}','{type}','{login}')";
            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection());
            dataBase.openConnection();
            if ( (start_date2.Text.Equals("")) || (finish_date2.Text.Equals("")) || (type2.Text.Equals("")) || (login2.Text.Equals("")))
            {
                MessageBox.Show("Заполните данные!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                if ((command.ExecuteNonQuery() == 1))
                    MessageBox.Show("Забранировано", "Готово");
             

            }
            

                        dataBase.closeConnection();

        }
        
            private void otel(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Недоступно на данный момент!");

        }
        private void nomer(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            this.Hide();
            window3.Show();

        }
    }
}
