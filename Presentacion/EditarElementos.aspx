<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarElementos.aspx.cs" Inherits="Presentacion.EditarElementos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <h3 class="mt-3">Editar</h3>
       

        <div class="col-6">

            <br />
            <div class="mb-3">

                <label>ID</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Nombre</label>
                <asp:TextBox runat="server" ID="txtdesc" CssClass="form-control" />  
            </div>
            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" />

                <asp:Button Text="Cancelar" OnClick="btnCancelar_Click" ID="btnCancelar" CssClass="btn  btn-danger" runat="server" />

                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass=" btn btn-secondary"  runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
