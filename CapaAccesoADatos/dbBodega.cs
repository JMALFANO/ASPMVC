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
    public class dbBodega : Conexion
    {

        public void Insertar(Bodega bodega)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "bodega_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", bodega.Nombre);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(bodega);
        }

       

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        public void Modificar(Bodega bodega)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "bodega_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_bodega", bodega.Id);
                    cmd.Parameters.AddWithValue("@Nombre", bodega.Nombre);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }



        public List<Bodega> ListarBodega()
        {

            List<Bodega> Lista = new List<Bodega>();

            SQL = "SELECT id_bodega, nombre FROM Bodega";

            //  SQL = "SELECT id_personal, Nombre + ' ' + Apellido FROM Personal WHERE id_privilegio = 2 ORDER BY Nombre";

            objComando.CommandText = SQL;

            try
            {
                objConexion.Open();
                SqlDataReader objReader = objComando.ExecuteReader();
                while (objReader.Read())
                {
                    Bodega Item = new Bodega();
                    Item.Id = (int)objReader["id_bodega"];
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


        private void SetID(Bodega bodega)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "bodega_sel_max_id_bodega";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        bodega.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }
        /*
                public Bodega ObtenerPorId(int id)
                {
                    SQL = "SELECT id_personal, Nombre, Apellido, Mail, Telefono, Contraseña, Activo, P.id_privilegio, P.privilegio_desc from Personal AS A ";
                    SQL = SQL + "INNER JOIN Privilegio AS P ON P.id_privilegio = A.id_privilegio ";
                    SQL = SQL + "WHERE id_personal =@id_personal ";
                    objComando.CommandText = SQL;
                    objComando.Parameters.AddWithValue("@id_", id);
                    Personal Item = null;
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
                }*/


        public List<Bodega> Listar()
        {
            List<Bodega> cat = new List<Bodega>();
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "bodega_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Bodega bodega = new Bodega
                        {
                            Id = Convert.ToInt32(row["id_bodega"]),
                            Nombre = Convert.ToString(row["nombre"]),

                        };
                        cat.Add(bodega);
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
                    cmd.CommandText = "bodega_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_bodega", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
