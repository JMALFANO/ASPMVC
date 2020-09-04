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
   public class dbProducto : Conexion
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
                    cmd.Parameters.AddWithValue("@descripcion", producto.Descripcion);
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


        public Producto ObtenerPorId(int id)
        {
            Producto producto = null;
            string connectionString = ConfigurationManager.ConnectionStrings["ASPNETMVC"].ToString();
            using (SqlConnection cnx = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnx;
                    cmd.CommandText = "producto_sel_by_id";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_producto", id);

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(table);
                    if (table.Rows.Count != 0)
                    {
                        DataRow row = table.Rows[0];
                        producto = new Producto

                        {
                           Id = Convert.ToInt32(row["id_producto"]),
                            Nombre = Convert.ToString(row["Nombre"]),
                            Descripcion = Convert.ToString(row["Descripcion"]),
                            Precio= Convert.ToInt64(row["Precio"]),
                            Categoria = Convert.ToInt32(row["id_categoria"]),
                            Bodega = Convert.ToInt32(row["id_bodega"]),
                            UnidadesProducto = Convert.ToInt32(row["unidades_producto"]),
                        };
                    }
                }
            }
            return producto;
        }

        /*
        public Producto ObtenerPorId(int id)
        {
            SQL = "SELECT id_producto, Nombre, Descripcion, Precio, id_categoria, id_bodega, unidades_producto FROM Producto WHERE id_producto = @id_producto";
            objComando.CommandText = SQL;
            objComando.Parameters.AddWithValue("@id_producto", id);
            Producto Item = null;
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
        */
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
                            Precio = Convert.ToInt64(row["precio"]),
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

        public Producto Map(SqlDataReader objReader)

        {
            Producto Item = new Producto();
            Item.Id = (int)objReader["id_producto"];
            Item.Nombre = (string)objReader["Nombre"];
            Item.Descripcion = (string)objReader["descripcion"];
            Item.Precio = (float)objReader["Precio"];
            Item.Categoria = (int)objReader["id_categoria"];
            Item.Bodega = (int)objReader["id_bodega"];
            Item.UnidadesProducto = (int)objReader["unidades_producto"];
            return Item;
        }

    }
}
