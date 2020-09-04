using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class ABMProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarBodega();
                CargarCategoria();
            }

            }


        protected void CargarBodega()
        {
            this.DropDownListBodega.DataSource = new admBodega().ListarBodega();
            this.DropDownListBodega.DataTextField = "Nombre";
            this.DropDownListBodega.DataValueField = "Id";
            this.DropDownListBodega.DataBind();
        }

        protected void CargarCategoria()
        {
            this.DropDownListCategoria.DataSource = new admCategoria().ListarCategoria();
            this.DropDownListCategoria.DataTextField = "Nombre";
            this.DropDownListCategoria.DataValueField = "Id";
            this.DropDownListCategoria.DataBind();
        }


        protected void btnCrearProducto_Click(object sender, EventArgs e)
        {
            String accion = Request.QueryString["accion"];
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            switch (accion)
            {
                case "modificar":
                    this.ActualizarProducto();
                    Response.Redirect("~/Productos.aspx");
                    break;
                case "nuevo":
                    this.CrearProducto();
                    Response.Redirect("~/Productos.aspx");
                    break;
            }
        }

        protected void CrearProducto()
        {
            Producto producto = ObtenerdeFormulario();
            new admProducto().Guardar(producto);
        }

        protected void ActualizarProducto()
        {
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            Producto producto = ObtenerdeFormulario();
            producto.Id = id;
            new admProducto().Guardar(producto);
        }

        protected Producto ObtenerdeFormulario()
        {
            Producto producto = new Producto();

            producto.Id = null;
            producto.Nombre = this.TextBoxNombre.Text;
            producto.Precio = float.Parse(this.TextBoxPrecio.Text);
            producto.Descripcion = this.TextBoxDescripcion.Text;


            
            producto.Categoria = int.Parse(DropDownListCategoria.SelectedValue);
            producto.Bodega = int.Parse(DropDownListBodega.SelectedValue);
            producto.UnidadesProducto = int.Parse(TextBoxCantidad.Text);

            return producto;
        }
           







    }
}