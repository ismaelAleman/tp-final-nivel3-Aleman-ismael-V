<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
    <div class="container-fluid ">
            <div class="row">
                <div class="col-6 mt-4" >
                    <div class="mb-3">
                        <label>Email</label>
                        <asp:TextBox runat="server" ID="txtemail" TextMode="Email" CssClass="form-control" />
                    </div>
                    <div class="mb-3">
                        <label>Contraseña</label>
                        <asp:TextBox runat="server" ID="txtpass" CssClass="form-control" TextMode="Password" />
                    </div>


                    <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" runat="server" />
                    <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" runat="server" />

                </div>
        </div>

    </div>
</asp:Content>
