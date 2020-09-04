<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMProducto.aspx.cs" Inherits="CapaPresentacion.ABMProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            ABM Producto
        </div>
        <div class="panel-body">
          Nombre:
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="Ingrese un nombre"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="LabelDescripcion" runat="server" Text="Descripcion:"></asp:Label>
            <asp:TextBox ID="TextBoxDescripcion" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxDescripcion" ErrorMessage="Ingrese una descripcion"></asp:RequiredFieldValidator>
            <br />
            <br />
                    <asp:Label ID="Label2" runat="server" Text="Precio:"></asp:Label>
            <asp:TextBox ID="TextBoxPrecio" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPrecio" ErrorMessage="Ingrese un precio"></asp:RequiredFieldValidator>
            <br />
            <br />
          <asp:Label ID="Label1" runat="server" Text="Cantidad:"></asp:Label>
            <asp:TextBox ID="TextBoxCantidad" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxCantidad" ErrorMessage="Ingrese una Cantidad"></asp:RequiredFieldValidator>
            <br />
            <br />

              <div style="margin-bottom: 10px" >
            <asp:Label ID="LabelCategoria" runat="server" Text="Categoria:"></asp:Label>
            <asp:DropDownList ID="DropDownListCategoria" runat="server" AutoPostBack="True">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownListCategoria" ErrorMessage="Seleccione un categoria"></asp:RequiredFieldValidator>
            </div>

             <div style="margin-bottom: 10px">
            <asp:Label ID="LabelBodega" runat="server" Text="Bodega:"></asp:Label>
            <asp:DropDownList ID="DropDownListBodega" runat="server" AutoPostBack="True">
            </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorBodega" runat="server" ControlToValidate="DropDownListBodega" ErrorMessage="Seleccione un bodega"></asp:RequiredFieldValidator>
            </div>   


            <asp:Button ID="btnCrearProducto" class="btn btn-primary"  runat="server" OnClick="btnCrearProducto_Click" Text="Insertar Producto" />
          
             &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>