<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Agregar2.aspx.cs" Inherits="Presentacion.Agregar2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-6">
        <div class="mb-3">
            <asp:Label  ID="lbltipo" runat="server" />
        </div>
        <div class="mb-3">
            <label>id</label>
            <asp:TextBox ID="txtId" CssClass="form-control"  runat="server" />

            <label>Nombre</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" />
        </div>
        <div class="mb-3">
            <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" runat="server" />
            <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-danger"   runat="server" />

        </div>
    </div>


</asp:Content>
