using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoADatos
{
    public class dbCategoria: Conexion
    {

        public void Insertar(Categoria categoria)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "categoria_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(categoria);
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        public void Modificar(Categoria categoria)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "categoria_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_categoria", categoria.Id);
                    cmd.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        public List<Categoria> ListarCategoria()
        {

            List<Categoria> Lista = new List<Categoria>();

            SQL = "SELECT id_categoria, nombre FROM Categoria";

            //  SQL = "SELECT id_personal, Nombre + ' ' + Apellido FROM Personal WHERE id_privilegio = 2 ORDER BY Nombre";

            objComando.CommandText = SQL;

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Categoria Item = new Categoria();
                    Item.Id = (int)objReader["id_categoria"];
                    Item.Nombre = (string)objReader["Nombre"];
                    //  Item.Apellido = (string)objReader["Apellido"];

                    Lista.Add(Item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
            }
            return Lista;
        }

        private void SetID(Categoria categoria)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "categoria_sel_max_id_categoria";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        categoria.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }

            public Categoria ObtenerPorId(int id)
            {
                SQL = "SELECT id_categoria, Nombre from Categoria ";
                SQL = SQL + "WHERE id_categoria=@id_categoria";
                objComando.CommandText = SQL;
                objComando.Parameters.AddWithValue("@id_categoria", id);
            Categoria Item = null;
            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();

                if (objReader.Read())
                {
                    Item = this.Map(objReader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objConexion.State == System.Data.ConnectionState.Open)
                {
                    objConexion.Close();
                }
            }
            return Item;
        }


        public List<Categoria> Listar()
        {
            List<Categoria> cat = new List<Categoria>();
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "categoria_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Categoria categoria = new Categoria
                        {
                            Id = Convert.ToInt32(row["id_categoria"]),
                            Nombre = Convert.ToString(row["nombre"]),
                          
                        };
                        cat.Add(categoria);
                    }
                }
            }
            return cat;
        }




        /// <summary>
        /// Elimina un registro coincidente con el Id Proporcionado
        /// </summary>        
        public void Delete(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "categoria_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_categoria", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Categoria Map(SqlDataReader objReader)

        {
            Categoria Item = new Categoria();
            Item.Id = (int)objReader["id_categoria"];
            Item.Nombre = (string)objReader["Nombre"];        
            return Item;
        }


    }
}
