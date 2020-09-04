<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABMCategoria.aspx.cs" Inherits="CapaPresentacion.ABMCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel panel-primary">
        <div class="panel-heading">
            ABM Categoria
        </div>
        <div class="panel-body">
          Nombre:&nbsp;
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ControlToValidate="TextBoxNombre" ErrorMessage="Ingrese un nombre"></asp:RequiredFieldValidator>
            <br />

            <asp:Button ID="btnCrearCategoria" class="btn btn-primary"  runat="server" OnClick="btnCrearCategoria_Click" Text="Insertar Categoria" />
          
             &nbsp;<asp:HyperLink ID="btnVolver" class="btn btn-primary" runat="server" NavigateUrl="~/Home.aspx">Volver</asp:HyperLink>
           
        </div>
    </div>
</asp:Content>