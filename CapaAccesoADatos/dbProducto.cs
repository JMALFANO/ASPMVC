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
   public class dbProducto
    {
        public void Insertar(Producto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_ins";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@id_categoria", producto.Categoria);
                    cmd.Parameters.AddWithValue("@id_bodega", producto.Bodega);
                    cmd.Parameters.AddWithValue("@unidades_producto", producto.UnidadesProducto);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser insertada en la tabla.");
                }
            }

            this.SetID(producto);
        }

        /// <summary>
        /// Actualiza el cliente correspondiente al Id proporcionado
        /// </summary>
        /// <param name="cliente">Valores utilizados para hacer el Update al registro</param>
        public void Modificar(Producto producto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_upd";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", producto.Id);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@descrpcion", producto.Descripcion);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@id_categoria", producto.Categoria);
                    cmd.Parameters.AddWithValue("@id_bodega", producto.Bodega);
                    cmd.Parameters.AddWithValue("@unidades_producto", producto.UnidadesProducto);
                    int count = cmd.ExecuteNonQuery();
                    if (count != 1) throw new Exception("La entidad no pudo ser modificada en la tabla.");
                }
            }
        }

        private void SetID(Producto producto)
        {
            //Creamos nuestro objeto de conexion usando nuestro archivo de configuraciones
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_sel_max_id_producto";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0] != DBNull.Value)
                    {
                        producto.Id = Convert.ToInt32(dataTable.Rows[0][0]);
                    }
                }
            }
        }
        /*
                public Producto ObtenerPorId(int id)
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


        public List<Producto> Listar()
        {
            List<Producto> cat = new List<Producto>();
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                cnx.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_sel_all";
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        Producto producto = new Producto
                        {
                            Id = Convert.ToInt32(row["id_producto"]),
                            Nombre = Convert.ToString(row["nombre"]),
                            Descripcion = Convert.ToString(row["descripcion"]),
                            Precio =Convert.ToDouble(row["precio"]),
                            Categoria = Convert.ToInt32(row["id_categoria"]),
                            Bodega = Convert.ToInt32(row["id_bodega"]),
                            UnidadesProducto = Convert.ToInt32(row["unidades_producto"])
                        };
                        cat.Add(producto);
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
                    cmd.CommandText = "producto_del";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
