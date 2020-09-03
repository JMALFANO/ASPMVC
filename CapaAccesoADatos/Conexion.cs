using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoADatos
{
    public class Conexion
    {
        protected SqlConnection objConexion = new SqlConnection();
        protected SqlCommand objComando = new SqlCommand();
        protected string SQL;
        public Conexion()
        {
            try
            {
                this.objConexion.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ASPNETMVC"].ConnectionString;
                this.objComando.Connection = this.objConexion;
                this.objComando.CommandType = System.Data.CommandType.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
