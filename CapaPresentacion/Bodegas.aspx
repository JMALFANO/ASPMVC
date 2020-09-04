<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bodegas.aspx.cs" Inherits="CapaPresentacion.Bodegas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            ABM Usuarios
        </div>
        <div class="panel-body">

            <asp:GridView ID="GridViewBodegas" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                     <Columns>
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkModificar" runat="server" NavigateUrl='<%# "~/ABMBodega.aspx?accion=modificar&id=" + Eval("id_bodega")%>'>Modificar</asp:HyperLink>
                                </ItemTemplate>

                            </asp:TemplateField>
                                                   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkEliminar" runat="server" NavigateUrl='<%# "~/ABMBodega.aspx?accion=eliminar&id=" + Eval("id_bodega")%>'>Eliminar</asp:HyperLink>
                                </ItemTemplate>

                            </asp:TemplateField>
                         <asp:BoundField DataField="id_bodega" HeaderText="id_bodega" SortExpression="Id_bodega" />
                         <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />          
                     </Columns>
                 </asp:GridView>
       
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ASPNETMVC %>" SelectCommand="SELECT [nombre], [id_bodega] FROM [Bodega]"></asp:SqlDataSource>
       
                <asp:HyperLink ID="btnListBodega" class="btn btn-primary" runat="server" NavigateUrl="~/ABMBodega.aspx?accion=nuevo">Insertar Bodega</asp:HyperLink>
          
             &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>
