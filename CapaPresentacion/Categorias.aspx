<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="CapaPresentacion.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            ABM Usuarios
        </div>
        <div class="panel-body">

            <asp:GridView ID="GridViewCategorias" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                     <Columns>
                          <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkModificar" runat="server" NavigateUrl='<%# "~/ABMCategoria.aspx?accion=modificar&id=" + Eval("id_categoria")%>'>Modificar</asp:HyperLink>
                                </ItemTemplate>

                            </asp:TemplateField>
                                                   <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkEliminar" runat="server" NavigateUrl='<%# "~/ABMCategoria.aspx?accion=eliminar&id=" + Eval("id_categoria")%>'>Eliminar</asp:HyperLink>
                                </ItemTemplate>

                            </asp:TemplateField>
                         <asp:BoundField DataField="id_categoria" HeaderText="id_categoria" SortExpression="Id_categoria" />
                         <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />          
                     </Columns>
                 </asp:GridView>
       
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ASPNETMVC %>" SelectCommand="SELECT * FROM [Categoria]"></asp:SqlDataSource>
       
                <asp:HyperLink ID="btnListCategoria" class="btn btn-primary" runat="server" NavigateUrl="~/ABMCategoria.aspx?accion=nuevo">Insertar Categoria</asp:HyperLink>
          
             &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>
