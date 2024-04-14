<%@ Page Title="Administrar" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="Presentacion.listarArticulos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .flex {
            display: flex;
            justify-content: center;
            align-content: center;
            gap: 15px 15px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row mt-3">
            <div class="col w-100">

                <div class="mb-3">
                    <h3>Administrar</h3>
                </div>
            </div>
            <div class="row mb-3">

                <div class="col w-100">
                    <div class="flex">

                        <div class="mb-3">
                            <asp:Button Text="Articulos" ID="btnArticulos" OnClick="btnArticulos_Click" CssClass="btn btn-primary" runat="server" />
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Categoria" ID="btnCategoria" OnClick="btnCategoria_Click" CssClass="btn btn-primary" runat="server" />
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Marca" ID="btnMarca" OnClick="btnMarca_Click" CssClass="btn btn-primary" runat="server" />
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Usuario" ID="btnUsuario" OnClick="btnUsuario_Click" CssClass ="btn btn-primary" runat="server" />
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:ScriptManager runat="server" />

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <asp:GridView runat="server" ID="dgvArticulos" AutoGenerateColumns="false" CssClass="table"
                OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" DataKeyNames="Id" OnLoad="dgvArticulos_Load">

                <Columns>
                   


                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>









    <a href="Agregar.aspx" class=" btn btn-primary">Agregar</a>
</asp:Content>
