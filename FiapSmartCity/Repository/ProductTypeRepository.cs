using FiapSmartCity.Models;
using System.Data.SqlClient;
using System.Data;

namespace FiapSmartCity.Repository
{
    internal class ProductTypeRepository
    {
        public IList<ProductType> GetAll()
        {
            IList<ProductType> list = new List<ProductType>();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT TYPEID, TYPEDESCRIPTION, MARKETED FROM PRODUCTTYPE  ";

                SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();


                while (dataReader.Read())
                {
                    // Recupera os dados
                    ProductType productType = new ProductType();
                    productType.TypeId = Convert.ToInt32(dataReader["TYPEID"]);
                    productType.TypeDescription = dataReader["TYPEDESCRIPTION"].ToString();
                    productType.Marketed = dataReader["MARKETED"].Equals("1");

                    // Adiciona o modelo da lista
                    list.Add(productType);
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return list;
        }

        public ProductType GetOne(int id)
        {

            ProductType productType = new ProductType();

            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "SELECT TYPEID, TYPEDESCRIPTION, MARKETED FROM PRODUCTTYPE WHERE TYPEID = @TYPEID ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@TYPEID", SqlDbType.Int);
                command.Parameters["@TYPEID"].Value = id;
                connection.Open();

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    // Recupera os dados
                    productType.TypeId = Convert.ToInt32(dataReader["TYPEID"]);
                    productType.TypeDescription = dataReader["TYPEDESCRIPTION"].ToString();
                    productType.Marketed = dataReader["MARKETED"].Equals("1");
                }

                connection.Close();

            } // Finaliza o objeto connection

            // Retorna a lista
            return productType;
        }

        public void Create(ProductType productType)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "INSERT INTO PRODUCTTYPE ( TYPEDESCRIPTION, MARKETED ) VALUES ( @descr, @comerc ) ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@descr", SqlDbType.Text);
                command.Parameters["@descr"].Value = productType.TypeDescription;
                command.Parameters.Add("@comerc", SqlDbType.Text);
                command.Parameters["@comerc"].Value = Convert.ToInt32(productType.Marketed);

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(ProductType productType)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "UPDATE PRODUCTTYPE SET TYPEDESCRIPTION = @descr , MARKETED = @comerc WHERE TYPEID = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@descr", SqlDbType.Text);
                command.Parameters.Add("@comerc", SqlDbType.Text);
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@descr"].Value = productType.TypeDescription;
                command.Parameters["@comerc"].Value = Convert.ToInt32(productType.Marketed);
                command.Parameters["@id"].Value = productType.TypeId;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            var connectionString = new ConfigurationBuilder()
                                        .SetBasePath(Directory.GetCurrentDirectory())
                                        .AddJsonFile("appsettings.json")
                                        .Build().GetConnectionString("FiapSmartCityConnection");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                String query =
                    "DELETE PRODUCTTYPE WHERE TYPEID = @id  ";

                SqlCommand command = new SqlCommand(query, connection);

                // Adicionando o valor ao comando
                command.Parameters.Add("@id", SqlDbType.Int);
                command.Parameters["@id"].Value = id;

                // Abrindo a conexão com  o Banco
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

        }
    }
}