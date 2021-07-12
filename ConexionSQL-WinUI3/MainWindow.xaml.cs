using Microsoft.UI.Xaml;

using System.Data.SqlClient;

namespace ConexionSQL_WinUI3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainWindow : Window
    {
        string connectionString = "Data Source=DESKTOP-R56EJQK\\SQLEXPRESS;Initial Catalog=GraphPriceOne;Integrated Security=SSPI;";
        public SqlConnection connection = new SqlConnection();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Conectar(object sender, RoutedEventArgs e)
        {
            try
            {
                if(connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    txtStatus.Text = connection.State.ToString();
                }
            }
            catch (SqlException ex)
            {
                txtStatus.Text = ex.ToString();
            }
        }
        private void Desconectar(object sender, RoutedEventArgs e)
        {
            connection.Close();
            txtStatus.Text = connection.State.ToString();
        }

    }
}
