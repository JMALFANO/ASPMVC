using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoADatos
{
    public class dbCategoria: Conexion
    {
        public void Agregar(Categoria categoria)
        {
            SQL = "INSERT INTO Categoria VALUES (@nombre)";
            objComando.Parameters.AddWithValue("@nombre", categoria.Nombre);

            objComando.CommandText = SQL;
            try
            {
                objConexion.Open();
                objComando.ExecuteNonQuery();
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
        }
    }
}
