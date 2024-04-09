<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Presentacion.Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="col-6 mt-4" >
            <div class="mb-3">
                <label>Email</label>
                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Contraseña</label>
                <asp:TextBox runat="server" TextMode="Password" ID="txtPass" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label>Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>

            <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-primary" runat="server" />
            <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger" runat="server" OnClick="btnCancelar_Click" />
        </div>
    </div>

</asp:Content>
