using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ABMBodega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                String accion = Request.QueryString["accion"];
                int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;

                switch (accion)
                {
                    case "eliminar":
                        EliminarBodega();
                        Response.Redirect("~/Bodegas.aspx");
                        break;
                    case "modificar":
                        CargarBodega(id);
                        this.btnCrearBodega.Text = "Modificar";
                        break;
                    case "nuevo":
                        this.btnCrearBodega.Text = "Agregar";
                        break;

                }
            }

        }

        protected void CargarBodega(int id)
        {
            Bodega bodega = new admBodega().ObtenerPorId(id);
            bodega.Id = id;
            this.TextBoxNombre.Text = bodega.Nombre;
        }

        protected void EliminarBodega()
        {
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            new admBodega().Eliminar(id);
        }

        protected void btnCrearBodega_Click(object sender, EventArgs e)
        {
            String accion = Request.QueryString["accion"];
        int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            switch (accion)
            {
                case "modificar":
                    this.ActualizarBodega();
                    Response.Redirect("~/Bodegas.aspx");
                        break;

                case "nuevo":
                    this.CrearBodega();
                    Response.Redirect("~/Bodegas.aspx");
                        break;
            }
        }

protected void CrearBodega()
{
    Bodega bodega = ObtenerdeFormulario();
    new admBodega().Guardar(bodega);
}

protected void ActualizarBodega()
{
    int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
    Bodega bodega = ObtenerdeFormulario();
    bodega.Id = id;
    new admBodega().Guardar(bodega);
}

protected Bodega ObtenerdeFormulario()
{
    Bodega bodega = new Bodega();

    bodega.Id = null;
    bodega.Nombre = this.TextBoxNombre.Text;
    return bodega;
}

    }
}
