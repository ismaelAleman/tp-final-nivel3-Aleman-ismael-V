<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditarUsuario.aspx.cs" Inherits="Presentacion.UsuarioNuevo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="usuario_titulo" style="text-align: center; margin-top: 15px;">
        <h2>Perfil</h2>
    </div>

    <div class="nuevoUsuario_content">



        <div class="sector1">


            <%-- id --%>
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox ID="txtId" class="form-control" runat="server" />
            </div>
            <%-- nombre --%>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" class="form-control" runat="server" />
            </div>
            <%-- Apellido --%>
            <div class="mb-3">
                <label for="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" class="form-control" runat="server" />
            </div>

            <%-- email --%>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" TextMode="Email" class="form-control" runat="server" />
            </div>
            <%-- pass actual--%>

            <div class="mb-3">
                <label  class="form-label">Contraseña</label>
                <asp:TextBox ID="txtPasword" class="form-control"  runat="server" />
               
            <%-- pass nuevo --%>
                <asp:Button Text="Cambiar contraseña" ID="btnPassNueva" CssClass="btn btn-secondary" OnClick="btnPassNueva_Click" runat="server" />
            </div>



            


            <%-- Admin --%>
            <div class="mb-3">
                <asp:Label ID="lbladmin" CssClass="form-label" Text="Administrador" runat="server" />                
                <asp:CheckBox ID="chkAdmin" Text="Si" runat="server" CssClass="chkAdmin" />
            </div>

            <div class="mb-3">
                <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click"  CssClass="btn btn-primary " runat="server" />
                <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" style= "margin-left:8px;" CssClass="btn btn-danger" runat="server" />
               
                <asp:Button Text="Eliminar Usuario"  CssClass="btn btn-secondary" ID="btnEliminar" runat="server" style= "margin-left:8px;" OnClick="btnEliminar_Click" OnClientClick="return confirmarEliminar();" />
            </div>

            

        </div>





        <div class="sector2">



            <%-- urlImagenPerfil --%>

            <div>

                <label for="txtUrlImagen" class="form-label">Imagen Perfil</label>

                <asp:TextBox ID="txtUrlImagen" class="form-control img-perfil" runat="server" AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />

            </div>

            <div class="imagenPerfil">

                <asp:ScriptManager runat="server" ID="scriptManager1" />

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <asp:Image runat="server" ID="imgPerfil" Width="250px" />

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>


        </div>


        <%--<div>        </div>--%>
    </div>


</asp:Content>
