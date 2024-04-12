<%@ Page Title="Agregar" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Presentacion.Agregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
       <asp:ScriptManager runat="server" />
    
    <div>
        <br />
        <h3>Agregar Articulo</h3>
    </div>



    <div class="row">

        <div class="col-6">
            <br />
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
                <asp:Button Text="Crear" ID="btnCrear" OnClick="btnCrear_Click" CssClass="btn btn-primary" runat="server" />

                <asp:Button Text="Cancelar" OnClick="btnCancelar_Click" ID="btnCancelar" CssClass="btn  btn-danger" runat="server" />
            </div>
        </div>

     

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
