<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="CapaPresentacion.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            Listado Productos
        </div>
        <div class="panel-body">

            <asp:GridView ID="GridViewCategorias" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="id_producto">
                     <Columns>

                                                   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkModificar" runat="server" NavigateUrl='<%# "~/ABMProducto.aspx?accion=modificar&id=" + Eval("id_producto")%>'>Modificar</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>

                                   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkEliminar" runat="server" NavigateUrl='<%# "~/ABMProducto.aspx?accion=eliminar&id=" + Eval("id_producto")%>'>Eliminar</asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>

                         <asp:BoundField DataField="id_producto" HeaderText="id_producto" SortExpression="id_producto" InsertVisible="False" ReadOnly="True" />
                         <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre" />          
                          <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" />
                          <asp:BoundField DataField="precio" HeaderText="precio" SortExpression="precio" />
                          <asp:BoundField DataField="id_categoria" HeaderText="id_categoria" SortExpression="id_categoria" />
                          <asp:BoundField DataField="id_bodega" HeaderText="id_bodega" SortExpression="id_bodega" />
                          <asp:BoundField DataField="unidades_producto" HeaderText="unidades_producto" SortExpression="unidades_producto" />
                     </Columns>
                 </asp:GridView>
       
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ASPNETMVC %>" SelectCommand="SELECT * FROM [Producto]"></asp:SqlDataSource>
       
                <asp:HyperLink ID="btnList" class="btn btn-primary" runat="server" NavigateUrl="~/ABMProducto.aspx?accion=nuevo">Insertar Producto</asp:HyperLink>
          
             &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>
