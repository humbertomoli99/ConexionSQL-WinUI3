using Microsoft.UI.Xaml;
using System;
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
                    //Crea una consulta de la tabla productos y retorna los product name
                    /*
                    SqlCommand consulta = new SqlCommand("Select * From Products where ProductID = 1", connection);
                    SqlDataReader dr = consulta.ExecuteReader();

                    if(dr.Read())
                    {
                            txtContent.Text = Convert.ToString(dr["ProductURL"]);
                    }
                    */
                    string insertArticle = "insert into Products(ProductName,ProductURL,UnitPriceTag,UnitPriceDesc,UnitPriceDescPorc,ProductTimePrice,ShippingPrice,StoreName,UnitsInStock)" +
                                                        "values ('Tarjeta de video','https://articulo.mercadolibre.com.mx/MLM-753142586-base-de-maquillaje-piel-mixtagrasa-fit-me-matte-maybelline-_JM#reco_item_pos=1&reco_backend=promotions-sorted-by-score-mlm-A&reco_backend_type=low_level&reco_client=seller-promotions&reco_id=70e0364d-7d0c-418d-af31-36fef1eca084&DEAL_ID=MLM8566&S=landingHubrebajas-verano&V=20&T=CarouselDynamic-home&L=LAS-MEJORES-OFERTAS-EN-REBAJAS&deal_print_id=0fd024e0-e39a-11eb-8100-7bb62ad573bc&c_id=carouseldynamic-home&c_element_order=undefined&c_campaign=LAS-MEJORES-OFERTAS-EN-REBAJAS&c_uid=0fd024e0-e39a-11eb-8100-7bb62ad573bc',100,100,100,'2021-07-12',123,NULL,1)";
                    SqlCommand comando = new SqlCommand(insertArticle, connection);
                    comando.ExecuteNonQuery();
                    connection.Close();
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
