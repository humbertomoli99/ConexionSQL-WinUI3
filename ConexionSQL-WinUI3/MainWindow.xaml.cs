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
        //string de conexion cambiarla con el nombre de tu computador
        string connectionString = "Data Source=DESKTOP-R56EJQK\\SQLEXPRESS;Initial Catalog=GraphPriceOne;Integrated Security=SSPI;";
        public SqlConnection connection = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();
            //mostrando status de conexion al iniciar la aplicacion
            txtStatus.Text = connection.State.ToString();
        }

        public void Conectar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    txtStatus.Text = connection.State.ToString();
                    //falta una consulta para obtener los datos y form para mostrar el ultimo dato agregado
                    //Crea una consulta de la tabla productos y retorna los product name
                    /*
                    SqlCommand consulta = new SqlCommand("Select * From TProducts where ProductID = 1", connection);
                    SqlDataReader dr = consulta.ExecuteReader();

                    if(dr.Read())
                    {
                            txtContent.Text = Convert.ToString(dr["ProductURL"]);
                    }
                    */
                    //connection.Close();
                }
            }
            catch (SqlException ex)
            {
                txtStatus.Text = ex.ToString();
            }
        }
        public void Insertar(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TxtName.Text == "" || TxtUrl.Text == "")
                {
                    txtStatus.Text = "Porfavor ingrese los datos";
                }else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    txtStatus.Text = "Porfavor abra la conexion";
                }
                else
                {
                    string insertArticle = "insert into TProducts(ProductName,ProductURL,UnitPriceTag,UnitPriceDesc,UnitPriceDescPorc,ProductTimePrice,ShippingPrice,StoreName,UnitsInStock)" +
                        "values ('" + TxtName.Text + "','" + TxtUrl.Text + "',100,100,100,'2021-07-12',123,NULL,1)";
                    SqlCommand comando = new SqlCommand(insertArticle, connection);
                    comando.ExecuteNonQuery();
                    //connection.Close();
                    txtStatus.Text = "Ok";
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