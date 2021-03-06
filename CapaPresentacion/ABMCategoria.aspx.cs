﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidades;


namespace CapaPresentacion
{
    public partial class ABMCategoria : System.Web.UI.Page
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
                        this.EliminarCategoria();
                        Response.Redirect("~/Categorias.aspx");
                        break;
                    case "modificar":
                        CargarCategoria(id);
                        this.btnCrearCategoria.Text = "Modificar";
                        break;
                    case "nuevo":
                        this.btnCrearCategoria.Text = "Agregar";
                        break;

                }
            }
        }

        protected void CargarCategoria(int id)
        {
            Categoria categoria = new admCategoria().ObtenerPorId(id);
            categoria.Id = id;
            this.TextBoxNombre.Text = categoria.Nombre;
        }



        protected void EliminarCategoria()
        {
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            new admCategoria().Eliminar(id);
        }
        protected void btnCrearCategoria_Click(object sender, EventArgs e)
        {
            String accion = Request.QueryString["accion"];
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            switch (accion)
            {
                case "modificar":
                    this.ActualizarCategoria();
                    Response.Redirect("~/Categorias.aspx");
                    break;
                case "nuevo":
                    this.CrearCategoria();
                    Response.Redirect("~/Categorias.aspx");
                    break;
            }
        }

        protected void CrearCategoria()
        {
            Categoria categoria = ObtenerdeFormulario();
            new admCategoria().Guardar(categoria);
        }

        protected void ActualizarCategoria()
        {
            int id = int.TryParse(Request.QueryString["id"], out id) ? id : 0;
            Categoria categoria = ObtenerdeFormulario();
            categoria.Id = id;
            new admCategoria().Guardar(categoria);
        }
       
        protected Categoria ObtenerdeFormulario()
        {
            Categoria categoria = new Categoria();

            categoria.Id = null;
            categoria.Nombre = this.TextBoxNombre.Text;
            return categoria;
        }
    }
}