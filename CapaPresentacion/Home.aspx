<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CapaPresentacion.Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
           Listados
        </div>
        <div class="panel-body">
             <asp:HyperLink ID="btnListProducto" class="btn btn-primary" runat="server" NavigateUrl="~/Productos.aspx">Listado de Productos</asp:HyperLink>
          
             <asp:HyperLink ID="btnListCategoria" class="btn btn-primary" runat="server" NavigateUrl="~/Categorias.aspx">Listado de Categorias</asp:HyperLink>
           
             <asp:HyperLink ID="btnListBodega" class="btn btn-primary" runat="server" NavigateUrl="~/Bodegas.aspx">Listado de Bodegas</asp:HyperLink>       
        </div>
    </div>
</asp:Content>