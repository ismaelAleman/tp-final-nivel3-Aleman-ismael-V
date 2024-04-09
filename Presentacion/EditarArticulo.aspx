<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarArticulo.aspx.cs" Inherits="Presentacion.EditarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <h3 class="mt-3">Editar Articulo</h3>

        <div class="col-6">
            
            <br />
            <div class="mb-3">

                <label>ID</label>
                <asp:TextBox runat="server" ID="TxtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Nombre</label>
                <asp:TextBox runat="server" ID="TxtNombre" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label>Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="form-control">
                </asp:DropDownList>
            </div>

            <div class="mb-3">
                <label>Categoria</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-control">
                </asp:DropDownList>
            </div>



            <div class="mb-3">
                <label>Precio</label>
                <asp:TextBox runat="server" ID="TxtPrecio" CssClass="form-control" />
            </div>


            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" runat="server" />

                <asp:Button Text="Cancelar" OnClick="btnCancelar_Click" ID="btnCancelar" CssClass="btn  btn-danger" runat="server" />
            </div>
        </div>

        <asp:ScriptManager runat="server" />

        <div class="col-6">


            <div class="mb-3">
                <br />
                <label>Descripcion</label>
                <asp:TextBox runat="server" ID="TxtDescripcion" TextMode="MultiLine" Rows="5" Style="resize: none" CssClass="form-control" />
            </div>

            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label>Imagen Articulo</label>
                        <asp:TextBox runat="server" ID="urlImagen" OnTextChanged="urlImagen_TextChanged" AutoPostBack="true" CssClass="form-control" />

                    </div>

                    <div class="mb-3">
                        <asp:Image ID="imgArticulo" runat="server" CssClass="img-fluid" Width="45%" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
</asp:Content>
